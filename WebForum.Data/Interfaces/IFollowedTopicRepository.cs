
using WebForum.Core.Models;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IFollowedTopicRepository
    {
        public Task<IReadOnlyCollection<FollowedTopicDto>?> GetAllAsync(Guid userId);
    }
}
