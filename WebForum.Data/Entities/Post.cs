using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Entities
{
    public class Post
    {
        public Guid Id = Guid.NewGuid();

        public Guid TopicId { get; set; }

        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("TopicId")]
        public User User { get; set; } 

        public required string Title { get; set; }
        
        public string? Text { get; set; }

        public DateTime CreationDate { get; init; } = DateTime.Now;

        public List<Comment> Comments { get; set; } = [];
    }
}
