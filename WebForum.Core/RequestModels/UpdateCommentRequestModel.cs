
namespace WebForum.Core.RequestModels
{
    public class UpdateCommentRequestModel
    {
        public long Id { get; set; }

        public Guid PostId { get; set; }

        public string? Text { get; set; }

        public string? ImageUrl { get; set; }
    }
}
