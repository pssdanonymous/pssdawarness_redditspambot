using PssdAwareness.RedditSpamBot.Api.Client.Dto;
using System.Collections.Generic;
using Flurl.Http;
using Flurl;
using System;
using PssdAwareness.RedditSpamBot.Common.Extension;
using System.Threading.Tasks;

namespace PssdAwareness.RedditSpamBot.Api.Client
{
    public class PushShiftClient : IPushShiftClient
    {
        public async Task<List<Post>> GetPostsAsync(string subredditName, DateTime dateFrom, DateTime dateTo)
        {
            var posts = await GetSubmissionSearchUrl(subredditName)
                .SetQueryParam("after", dateFrom.ToUnixTime())
                .SetQueryParam("before", dateTo.ToUnixTime())
                .GetAsync()
                .ReceiveJson<PostSearchResult>();

            return posts.Posts;
        }

        private string GetApiHostUrl()
            => "https://api.pushshift.io/reddit";

        private string GetSubmissionSearchUrl(string subredditName)
        {
            return GetApiHostUrl()
                .AppendPathSegment("submission/search")
                .SetQueryParam("subreddit", subredditName);
        }
    }
}
