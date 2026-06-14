
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Entities
{
    public class Comment : IId<long>
    {
        public long Id { get; set; }

        public required Guid PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post? Post { get; set; }

        public required Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public required string Text { get; set; }

        public required bool IsDeleted { get; set; }

        public DateTime CreationDate { get; init; } = DateTime.Now;
    }
}
