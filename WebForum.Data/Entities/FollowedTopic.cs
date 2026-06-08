
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Entities
{
    public class FollowedTopic : IId<long>
    {
        public long Id { get; set; }

        public Guid TopicId { get; set; }

        [ForeignKey(nameof(TopicId))]
        public required Topic Topic { get; set; }

        public Guid UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public required User User { get; set; }
    }
}
