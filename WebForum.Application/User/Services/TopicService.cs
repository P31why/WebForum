using WebForum.Application.User.Interface;
using WebForum.Core.Models;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Application.User.Services
{
    public class TopicService(ITopicRepository topicRepository,
                              TopicMapper mapper) : ITopicService
    {
        public async Task<TopicDto> AddAsync(TopicDto topicDto)
        {
            var entity = await topicRepository.CreateEntityAsync(mapper.DtoToEntity(topicDto));

            bool isCreated = await topicRepository.CommitDbAsync();

            if (isCreated)
                throw new Exception("Error creating topic");

            return mapper.EntityToDto(entity);
        }

        public async Task<IReadOnlyCollection<TopicShortDto>> GetAllShortAsync(Guid? userId = null)
        {
            return (await topicRepository.GetCollectionShortDtoAsync(userId)) ?? Array.Empty<TopicShortDto>();
        }

        public async Task<TopicDto> GetByIdAsync(Guid id)
        {
            return await topicRepository.GetDtoAsync(id);
        }

        public async Task<bool> UpdateAsync(TopicDto topicDto)
        {
            return await topicRepository.UpdateEntityAsync(topicDto);
        }
    }
}
