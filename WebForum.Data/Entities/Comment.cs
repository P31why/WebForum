
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Entities
{
    public class Comment : IId<long>
    {
        [Key]
        public long Id { get; set; }

        public Guid PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public required string Text { get; set; }

        public DateTime CreationDate { get; init; } = DateTime.Now;
    }
}
