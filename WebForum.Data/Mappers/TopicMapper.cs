
using Riok.Mapperly.Abstractions;
using WebForum.Core.Models;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Mappers
{
    [Mapper]
    public partial class TopicMapper
    {
        [UserMapping]
        public TopicDto EntityToDto(Topic entity)
        {
            return new TopicDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Title = entity.Title,
                Description = entity.Description,
                IsDeleted = entity.IsDeleted
            };
        }

        [UserMapping]
        public Topic DtoToEntity(TopicDto dto)
        {
            return new Topic
            {
                Id = dto.Id,
                UserId = dto.UserId,
                Title = dto.Title,
                Description = dto.Description,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
