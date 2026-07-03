
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Entities
{
    public class FollowedTopic : IId<long>
    {
        public required long Id { get; set; }

        public required Guid TopicId { get; set; }

        [ForeignKey(nameof(TopicId))]
        public Topic? Topic { get; set; }

        public required Guid UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
