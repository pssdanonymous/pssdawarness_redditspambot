using Newtonsoft.Json;
using System.Collections.Generic;

namespace PssdAwareness.RedditSpamBot.Api.Client.Dto
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PostSearchResult
    {
        [JsonProperty("data")]
        public List<Post> Posts { get; set; }
    }
}
