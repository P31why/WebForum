
namespace WebForum.Core.RequestModels
{
    public class CreateCommentRequestModel
    {
        public required Guid UserId { get; set; }

        public required Guid PostId { get; set; }

        public required string Text { get; set; }

        public string? ImageUrl { get; set; }
    }
}
