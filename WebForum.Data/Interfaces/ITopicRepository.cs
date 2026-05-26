
using WebForum.Core.Models;

namespace WebForum.Infrastructure.Interfaces
{
    public interface ITopicRepository
    {
        public Task UpdateEntityAsync(TopicDto topicDto);

        public Task<TopicDto> GetDtoAsync(Guid topicId);

        public Task<TopicShortDto> GetShortDtoAsync(Guid topicId);

        public Task<IReadOnlyCollection<TopicDto>> GetCollectionDtoAsync(Guid? userId);

        public Task<IReadOnlyCollection<TopicShortDto>> GetCollectionShortDtoAsync(Guid? userId);
    }
}
