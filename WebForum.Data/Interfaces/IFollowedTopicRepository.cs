
using WebForum.Core.Models;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IFollowedTopicRepository : IBaseRepository<long, FollowedTopic>
    {
        public Task<IReadOnlyCollection<FollowedTopicDto>?> GetAllAsync(Guid userId);
    }
}
