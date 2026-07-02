using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.Application.User.Interface
{

    public interface ITopicService
    {
        public Task<TopicDto> AddAsync(CreateTopicRequestModel topicRequest);

        public Task<bool> UpdateAsync(TopicDto topicDto);

        public Task<IReadOnlyCollection<TopicShortDto>> GetAllShortAsync(Guid? userId = null);

        public Task<TopicDto> GetByIdAsync(Guid id);

        public Task<bool> DeleteAsync(Guid id, DeleteType type);
    }
}
