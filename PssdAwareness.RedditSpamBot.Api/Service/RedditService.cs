using PssdAwareness.RedditSpamBot.Api.Client;
using PssdAwareness.RedditSpamBot.Api.Client.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PssdAwareness.RedditSpamBot.Api.Service
{
    public class RedditService : IRedditService
    {
        private readonly Dictionary<string, Post> _lastPosts;

        private readonly IRedditClient _client;
        private readonly IKeywordsService _keywordsService;
        private readonly ICommentsService _commentsService;
        private readonly ISubredditNamesService _subredditNamesService;

        public RedditService(
            IRedditClient client, 
            IKeywordsService keywordsService, 
            ICommentsService commentsService,
            ISubredditNamesService subredditNamesService)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _keywordsService = keywordsService ?? throw new ArgumentNullException(nameof(keywordsService));
            _commentsService = commentsService ?? throw new ArgumentNullException(nameof(commentsService));
            _subredditNamesService = subredditNamesService ?? throw new ArgumentNullException(nameof(subredditNamesService));  

            _lastPosts = new Dictionary<string, Post>();

            _client.Connect();
        }

        public async Task Spam()
         {
            foreach (var subredditName in _subredditNamesService.GetSubredditNames())
            {
                if (!_lastPosts.TryGetValue(subredditName, out var lastPost))
                {
                    var post = (await _client.GetNewPostsAsync(subredditName, 1)).Single();
                    _lastPosts.Add(subredditName, post);

                    continue;
                }

                var posts = (await _client.GetPostsAsync(subredditName, lastPost.CreatedAt, DateTime.UtcNow));
                foreach (var post in posts)
                {
                    foreach (var keywordLine in _keywordsService.GetKeywords())
                    {
                        if (post.Text.Contains(keywordLine))
                        {
                            _client.Comment(post, _commentsService.GetComment());
                            _lastPosts[subredditName] = post;

                            return;
                        }
                    }
                }
            }
        }
    }
}
