using System;

namespace PssdAwareness.RedditSpamBot.Api.Client
{
    public class DataMapper : IDataMapper
    {
        public Dto.Post Map(RedditSharp.Things.Post post)
        {
            return new Dto.Post()
            {
                Id = post.Id,
                Author = post.Author.FullName,
                Text = post.SelfText,
                Title = post.Title,
                Url = post.Url,
                CreatedAt = post.CreatedUTC.UtcDateTime
            };
        }
    }
}
