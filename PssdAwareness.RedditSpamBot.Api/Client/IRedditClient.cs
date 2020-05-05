using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PssdAwareness.RedditSpamBot.Api.Client
{
    public interface IRedditClient
    {
        void Connect();
        Task<List<Dto.Post>> GetNewPostsAsync(string subredditName, int limit);
        Task<List<Dto.Post>> GetPostsAsync(string subredditName, DateTime dateFrom, DateTime dateTo);
        void Comment(Dto.Post post, string message);
    }
}
