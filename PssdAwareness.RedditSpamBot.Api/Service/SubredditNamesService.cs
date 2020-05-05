using PssdAwareness.RedditSpamBot.Api.Configuration;
using System.Collections.Generic;

namespace PssdAwareness.RedditSpamBot.Api.Service
{
    public class SubredditNamesService : TextResourceService<ISubredditNamesServiceConfiguration>, ISubredditNamesService
    {
        public SubredditNamesService(ISubredditNamesServiceConfiguration config) : base(config) { }

        public List<string> GetSubredditNames()
        {
            return _resources;
        }
    }
}
