
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.Application.User.Interfaces
{
    public interface IFollowedTopicService
    {
        public Task<FollowedTopicDto?> GetUserFollowedTopicByIdAsync(long id);

        public Task<IReadOnlyCollection<FollowedTopicDto>> GetUserFollowedTopicsAsync(Guid userId);

        public Task<FollowedTopicDto> AddUserFollowedTopicAsync(FollowedTopicDto dto);

        public Task<bool> DeleteUserFollowedTopicAsync(long Id, DeleteType type);
    }
}
