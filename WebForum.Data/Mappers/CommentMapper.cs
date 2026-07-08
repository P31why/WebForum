
using Riok.Mapperly.Abstractions;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
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

                ImageUrl = dto.ImageUrl,

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

                ImageUrl= entity.ImageUrl,

                IsDeleted = entity.IsDeleted,

                CreationDate = entity.CreationDate,
            };
        }

        [UserMapping]
        public Comment RequestToEntity(CreateCommentRequestModel requestModel)
        {
            return new Comment
            {
                UserId = requestModel.UserId,
                PostId = requestModel.PostId,
                Text = requestModel.Text,
                ImageUrl = requestModel.ImageUrl,
                IsDeleted = false,
                CreationDate = DateTime.UtcNow
            };
        }
    }
}
