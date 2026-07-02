
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface ITopicRepository : IBaseRepository<Guid, Topic>
    {
        public Task<bool> UpdateEntityAsync(TopicDto topicDto);

        public Task<TopicDto> GetDtoAsync(Guid topicId);

        public Task<TopicShortDto> GetShortDtoAsync(Guid topicId);

        public Task<bool> GetSameNameTopic(string name);

        public Task<IReadOnlyCollection<TopicDto>> GetCollectionDtoAsync(Guid? userId);

        public Task<IReadOnlyCollection<TopicShortDto>> GetCollectionShortDtoAsync(Guid? userId);
    }
}
