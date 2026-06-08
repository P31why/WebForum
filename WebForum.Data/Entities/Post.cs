using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Entities
{
    public class Post : IId<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public Guid TopicId { get; set; }

        [ForeignKey(nameof(TopicId))]
        public required Topic Topic { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required User User { get; set; } 

        public required string Title { get; set; }
        
        public string? Text { get; set; }

        public required bool IsDeleted { get; set; }

        public DateTime CreationDate { get; init; } = DateTime.Now;
    }
}
