using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PssdAwareness.RedditSpamBot.Common.Extension;
using System;

namespace PssdAwareness.RedditSpamBot.Common.Json
{
    public class DateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateTime));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Integer)
            {
                var dateUnix = token.ToObject<long>();
                return dateUnix.FromUnixTime();
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
