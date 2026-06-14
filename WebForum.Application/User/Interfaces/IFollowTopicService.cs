
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.Application.User.Interfaces
{
    public interface IFollowTopicService
    {
        public Task<IReadOnlyCollection<FollowedTopicDto>> GetAllFollowedTopicsAsync(Guid userId);

        public Task<FollowedTopicDto> AddAsync(FollowedTopicDto dto);

        public Task<bool> DeleteAsync(long Id, DeleteType type);
    }
}
