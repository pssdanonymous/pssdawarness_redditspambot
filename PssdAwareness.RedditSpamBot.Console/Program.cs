using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using PssdAwareness.RedditSpamBot.Api.Client;
using PssdAwareness.RedditSpamBot.Api.Configuration;
using PssdAwareness.RedditSpamBot.Api.Service;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PssdAwareness.RedditSpamBot.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var redditService = serviceProvider.GetService<IRedditService>();

            while (true)
            {
                await redditService.Spam();
                Thread.Sleep(604800000);
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            // Client
            services.AddTransient<IDataMapper, DataMapper>();
            services.AddTransient<IRedditClient, RedditClient>();
            services.AddTransient<IPushShiftClient, PushShiftClient>();

            // Configuration
            services.AddTransient<IClientConfiguration, ClientConfiguration>();
            services.AddTransient<IKeywordsServiceConfiguration, KeywordsServiceConfigurationConsole>();
            services.AddTransient<ISubredditNamesServiceConfiguration, SubredditNamesServiceConfigurationConsole>();
            services.AddTransient<ICommentsServiceConfiguration, CommentsServiceConfigurationConsole>();
            services.AddTransient<ICommentsService, CommentsService>();

            // Service
            services.AddTransient<IRedditService, RedditService>();
            services.AddTransient<IKeywordsService, KeywordsService>();
            services.AddTransient<ISubredditNamesService, SubredditNamesService>();

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
