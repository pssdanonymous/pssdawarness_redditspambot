using PssdAwareness.RedditSpamBot.Api.Client.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PssdAwareness.RedditSpamBot.Api.Client
{
    public interface IPushShiftClient
    {
        Task<List<Post>> GetPostsAsync(string subredditName, DateTime dateFrom, DateTime dateTo);
    }
}
