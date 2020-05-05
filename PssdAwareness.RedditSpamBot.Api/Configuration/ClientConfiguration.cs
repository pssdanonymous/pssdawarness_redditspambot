using Microsoft.Extensions.Configuration;
using System;

namespace PssdAwareness.RedditSpamBot.Api.Configuration
{
    public class ClientConfiguration : IClientConfiguration
    {
        private readonly IConfiguration _config;

        public ClientConfiguration(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public string Username 
            => _config["RedditApi:ApiUsername"];

        public string Password 
            => _config["RedditApi:ApiPassword"];
    }
}
