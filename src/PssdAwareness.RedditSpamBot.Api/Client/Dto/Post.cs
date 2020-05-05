using Newtonsoft.Json;
using PssdAwareness.RedditSpamBot.Common.Json;
using System;

namespace PssdAwareness.RedditSpamBot.Api.Client.Dto
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Post
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("selftext")]
        public string Text { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("created_utc")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }
    }
}
