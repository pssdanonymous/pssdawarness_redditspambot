using System.Collections.Generic;

namespace PssdAwareness.RedditSpamBot.Api.Service
{
    public interface ISubredditNamesService
    {
        List<string> GetSubredditNames();
    }
}
