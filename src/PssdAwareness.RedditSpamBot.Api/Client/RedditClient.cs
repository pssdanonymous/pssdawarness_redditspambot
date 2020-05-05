using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PssdAwareness.RedditSpamBot.Api.Configuration;
using RedditSharp;
using RedditSharp.Things;

namespace PssdAwareness.RedditSpamBot.Api.Client
{
    public class RedditClient : IRedditClient
    {
        private bool _connected;

        private AuthenticatedUser _user;
        
        private readonly Reddit _client;
        private readonly IDataMapper _mapper;
        private readonly IClientConfiguration _config;
        private readonly IPushShiftClient _pushShiftClient;

        public RedditClient(IClientConfiguration config, IDataMapper mapper, IPushShiftClient pushShiftClient)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _pushShiftClient = pushShiftClient ?? throw new ArgumentNullException(nameof(pushShiftClient));

            _client = new Reddit();
        }

        public void Connect()
        {
            _user = _client.LogIn(_config.Username, _config.Password);
            _connected = true;
        }

        public async Task<List<Dto.Post>> GetPostsAsync(string subredditName, DateTime dateFrom, DateTime dateTo)
        {
            IsConnected();

            return await _pushShiftClient.GetPostsAsync(subredditName, dateFrom, dateTo);
        }

        public async Task<List<Dto.Post>> GetNewPostsAsync(string subredditName, int limit)
        {
            IsConnected();

            var subreddit = await _client.GetSubredditAsync(subredditName);
            var posts = subreddit.New.Take(limit).ToList();
            
            return posts.Select(_mapper.Map).ToList();
        }

        public void Comment(Dto.Post postDto, string message)
        {
            IsConnected();

            var post = _client.GetPost(postDto.Url);
            post.Comment(message);
        }

        private void IsConnected()
        {
            if (!_connected)
            {
                throw new InvalidOperationException($"Client is not connected. Use {nameof(Connect)} method first.");
            }
        }
    }
}
