
namespace WebForum.Core.Models
{
    public class TopicDto : TopicShortDto
    {
        public Guid UserId { get; init; }
        
        public string? Description { get; set; }
    }

    public class TopicShortDto
    {
        public Guid Id { get; init; }

        public string Title { get; set; }

    }
}
