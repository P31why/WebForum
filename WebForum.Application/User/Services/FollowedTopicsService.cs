
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Application.User.Services
{
    public class FollowedTopicsService(IFollowedTopicRepository repository,
                                       FollowedTopicsMapper mapper) : IFollowTopicService
    {
        public async Task<FollowedTopicDto> AddAsync(FollowedTopicDto dto)
        {
            var entity = await repository.CreateEntityAsync(mapper.DtoToEntity(dto));

            bool isCreated = await repository.CommitDbAsync();

            if (!isCreated)
                throw new Exception("Error with creating FollowedTopic entity");

            return mapper.EntityToDto(entity);
        }

        public async Task<bool> DeleteAsync(long id, DeleteType type = DeleteType.Full)
        {
            // TODO: second delete variant
            return await repository.DeleteEntityAsync(id, type);
        }

        public async Task<IReadOnlyCollection<FollowedTopicDto>> GetAllFollowedTopicsAsync(Guid userId)
        {
            return await repository.GetAllAsync(userId) ?? Array.Empty<FollowedTopicDto>();
        }
    }
}
