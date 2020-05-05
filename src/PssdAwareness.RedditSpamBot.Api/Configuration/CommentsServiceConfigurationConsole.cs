using Microsoft.Extensions.Configuration;
using System;

namespace PssdAwareness.RedditSpamBot.Api.Configuration
{
    public class CommentsServiceConfigurationConsole : ICommentsServiceConfiguration
    {
        private readonly IConfiguration _config;

        public CommentsServiceConfigurationConsole(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public string ResourcePath
            => _config["TextResources:CommentsPath"];
    }
}
