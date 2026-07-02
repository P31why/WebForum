
namespace WebForum.Core.RequestModels
{
    public class CreatePostRequestModel
    {
        public required Guid UserId { get; set; }

        public required Guid TopicId { get; set; }

        public required string Title { get; set; }

        public string? Text{ get; set; }
    }
}
