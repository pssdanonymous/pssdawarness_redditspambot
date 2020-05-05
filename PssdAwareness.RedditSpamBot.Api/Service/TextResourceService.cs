using PssdAwareness.RedditSpamBot.Api.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PssdAwareness.RedditSpamBot.Api.Service
{
    public abstract class TextResourceService<TConfiguration>  
        where TConfiguration : IResourceServiceConfiguration
    {
        protected List<string> _resources;
        private readonly TConfiguration _config;

        public TextResourceService(TConfiguration config)
        {
            _config = config;
            Load();
        }

        private void Load()
        {
            var text = File.ReadAllText(Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _config.ResourcePath)));
            _resources = text.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
