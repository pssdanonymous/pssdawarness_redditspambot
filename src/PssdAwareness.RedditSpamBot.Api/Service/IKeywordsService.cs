using System.Collections.Generic;

namespace PssdAwareness.RedditSpamBot.Api.Service
{
    public interface IKeywordsService
    {
        List<string> GetKeywords();
    }
}
