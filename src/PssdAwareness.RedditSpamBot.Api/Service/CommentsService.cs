using PssdAwareness.RedditSpamBot.Api.Configuration;
using System;

namespace PssdAwareness.RedditSpamBot.Api.Service
{
    public class CommentsService : TextResourceService<ICommentsServiceConfiguration>, ICommentsService
    {
        public CommentsService(ICommentsServiceConfiguration config) : base(config) { }

        public string GetComment()
        {
            var random = new Random();
            return _resources[random.Next(1, _resources.Count) - 1];
        }
    }
}
