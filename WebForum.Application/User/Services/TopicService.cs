using WebForum.Application.User.Interface;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Application.User.Services
{
    public class TopicService(ITopicRepository repository,
                              TopicMapper mapper) : ITopicService
    {
        public async Task<TopicDto> AddAsync(CreateTopicRequestModel topicRequest)
        {
            if (await repository.GetSameNameTopic(topicRequest.Title))
                throw new Exception("Error creating topic, same title");

            var entity = await repository.CreateEntityAsync(mapper.RequestToEntity(topicRequest));

            bool isCreated = await repository.CommitDbAsync();

            if (!isCreated)
                throw new Exception("Error creating topic");

            return mapper.EntityToDto(entity);
        }

        public async Task<bool> DeleteAsync(Guid id, DeleteType type)
        {
            return await repository.DeleteEntityAsync(id, type);
        }

        public async Task<IReadOnlyCollection<TopicShortDto>> GetAllShortAsync(Guid? userId = null)
        {
            return (await repository.GetCollectionShortDtoAsync(userId)) ?? Array.Empty<TopicShortDto>();
        }

        public async Task<TopicDto> GetByIdAsync(Guid id)
        {
            return await repository.GetDtoAsync(id);
        }

        public async Task<bool> UpdateAsync(UpdateTopicRequestModel topicDto)
        {
            return await repository.UpdateEntityAsync(topicDto);
        }
    }
}
