using WebForum.Core.Models;

namespace WebForum.Application.User.Interface
{

    public interface ITopicService
    {
        public Task<IReadOnlyCollection<FollowedTopicDto>> GetAllFollowedTopicsAsync(Guid userId);

        public Task<IReadOnlyCollection<TopicShortDto>> GetAllShortAsync(Guid? userId = null);

        public Task<TopicDto> GetByIdAsync(Guid id);
    }
}
