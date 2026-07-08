
namespace WebForum.Core.Models
{
    public class PostDto : PostShortDto
    {
        public string? Text { get; set; }

        public string? ImageUrl { get; set; }
    }

    public class PostShortDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid TopicId { get; set; }

        public required string Title { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
