using Microsoft.Extensions.Configuration;
using System;

namespace PssdAwareness.RedditSpamBot.Api.Configuration
{
    public class SubredditNamesServiceConfigurationConsole : ISubredditNamesServiceConfiguration
    {
        private readonly IConfiguration _config;

        public SubredditNamesServiceConfigurationConsole(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public string ResourcePath 
            => _config["TextResources:SubredditNamesPath"];
    }
}
