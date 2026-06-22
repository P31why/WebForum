using WebForum.Core.Models;

namespace WebForum.Application.User.Interface
{

    public interface ITopicService
    {
        public Task<TopicDto> AddAsync(TopicDto topicDto);

        public Task<bool> UpdateAsync(TopicDto topicDto);

        public Task<IReadOnlyCollection<TopicShortDto>> GetAllShortAsync(Guid? userId = null);

        public Task<TopicDto> GetByIdAsync(Guid id);
    }
}
