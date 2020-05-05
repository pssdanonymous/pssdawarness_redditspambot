using PssdAwareness.RedditSpamBot.Api.Configuration;
using System.Collections.Generic;

namespace PssdAwareness.RedditSpamBot.Api.Service
{
    public class KeywordsService : TextResourceService<IKeywordsServiceConfiguration>, IKeywordsService
    {
        public KeywordsService(IKeywordsServiceConfiguration config) : base(config) { }

        public List<string> GetKeywords()
        {
            return _resources;
        }
    }
}
