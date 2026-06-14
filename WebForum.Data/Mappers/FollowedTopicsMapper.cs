
using Riok.Mapperly.Abstractions;
using WebForum.Core.Models;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Mappers
{
    [Mapper]
    public partial class FollowedTopicsMapper
    {
        [UserMapping]
        public FollowedTopic DtoToEntity(FollowedTopicDto dto)
        {
            return new FollowedTopic
            {
                Id = dto.Id,
                UserId = dto.UserId,
                TopicId = dto.TopicId,
            };
        }

        [UserMapping]
        public FollowedTopicDto EntityToDto(FollowedTopic entity)
        {
            return new FollowedTopicDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                TopicId = entity.TopicId,
            };
        }
    }
}
