using Microsoft.Extensions.Configuration;
using System;

namespace PssdAwareness.RedditSpamBot.Api.Configuration
{
    public class KeywordsServiceConfigurationConsole : IKeywordsServiceConfiguration
    {
        private readonly IConfiguration _config;

        public KeywordsServiceConfigurationConsole(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public string ResourcePath 
            => _config["TextResources:KeywordsPath"];
    }
}
