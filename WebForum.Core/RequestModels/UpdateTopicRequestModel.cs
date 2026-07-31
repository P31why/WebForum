
namespace WebForum.Core.RequestModels
{
    public class UpdateTopicRequestModel
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
