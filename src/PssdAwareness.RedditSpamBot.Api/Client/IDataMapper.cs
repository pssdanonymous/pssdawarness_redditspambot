using RedditSharp.Things;

namespace PssdAwareness.RedditSpamBot.Api.Client
{
    public interface IDataMapper
    {
        Dto.Post Map(Post post);
    }
}
