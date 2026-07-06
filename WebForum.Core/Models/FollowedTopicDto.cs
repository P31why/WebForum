
namespace WebForum.Core.Models
{
    public class FollowedTopicDto
    {
        public long Id { get; set; }

        public Guid UserId {  get; set; }

        public Guid TopicId { get; set; }

        public required bool IsDeleted { get; set; }
    }
}
