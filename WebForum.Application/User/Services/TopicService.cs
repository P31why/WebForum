using WebForum.Application.User.Interface;
using WebForum.Core.Models;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Application.User.Services
{
    public class TopicService(ITopicRepository topicRepository, IFollowedTopicRepository followedTopicRepository) : ITopicService
    {
        public async Task<IReadOnlyCollection<FollowedTopicDto>> GetAllFollowedTopicsAsync(Guid userId)
        {
            return (await followedTopicRepository.GetAllAsync(userId)) ?? Array.Empty<FollowedTopicDto>();
        }

        public async Task<IReadOnlyCollection<TopicShortDto>> GetAllShortAsync(Guid? userId = null)
        {
            return (await topicRepository.GetCollectionShortDtoAsync(userId)) ?? Array.Empty<TopicShortDto>();
        }

        public async Task<TopicDto> GetByIdAsync(Guid id)
        {
            return await topicRepository.GetDtoAsync(id);
        }
    }
}
