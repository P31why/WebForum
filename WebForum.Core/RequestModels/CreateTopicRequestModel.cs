
namespace WebForum.Core.RequestModels
{
    public class CreateTopicRequestModel
    {
        public required Guid UserId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
