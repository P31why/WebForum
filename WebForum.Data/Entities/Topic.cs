
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Entities
{
    public class Topic : IId<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required User Creator { get; set; }
            
        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; init; } = DateTime.Now;
    }
}
