
using Riok.Mapperly.Abstractions;
using WebForum.Core.Models;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Mappers
{
    [Mapper]
    public partial class CommentMapper
    {
        [UserMapping]
        public Comment DtoToEntity(CommentDto dto)
        {
            return new Comment
            {
                Id = dto.Id,

                PostId = dto.PostId,

                UserId = dto.UserId,

                Text = dto.Text,

                IsDeleted = dto.IsDeleted,

                CreationDate = dto.CreationDate
            };
        }

        [UserMapping]
        public CommentDto EntityToDto(Comment entity)
        {
            return new CommentDto
            {
                Id = entity.Id,

                UserId = entity.UserId,

                PostId = entity.PostId,

                Text = entity.Text,

                IsDeleted = entity.IsDeleted,

                CreationDate = entity.CreationDate,
            };
        }
    }
}
