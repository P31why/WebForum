
using Riok.Mapperly.Abstractions;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
using WebForum.Infrastructure.Entities;

namespace WebForum.Mapper
{
    [Mapper]
    public partial class PostMapper
    {
        [UserMapping]
        public Post ModelToEntityCreate(PostDto dto)
        {
            return new Post
            {
                Id = dto.Id,

                TopicId = dto.TopicId,

                UserId = dto.UserId,

                Title = dto.Title,

                Text = dto.Text,

                ImageUrl = dto.ImageUrl,

                IsDeleted = false,

                CreationDate = dto.CreationDate,
            };
        }

        [UserMapping]
        public PostDto EntityToModel(Post entity)
        {
            return new PostDto
            {
                Id = entity.Id,
                TopicId = entity.TopicId,

                UserId = entity.UserId,

                Title = entity.Title,

                Text = entity.Text,

                ImageUrl = entity.ImageUrl,

                IsDeleted = entity.IsDeleted,

                CreationDate = entity.CreationDate,
            };
        }

        [UserMapping]
        public PostShortDto EntitytoShortDto(Post entity)
        {
            return new PostShortDto
            {
                Id = entity.Id,

                TopicId = entity.TopicId,

                UserId = entity.UserId,

                Title = entity.Title,

                IsDeleted = entity.IsDeleted,

                CreationDate = entity.CreationDate,
            };
        }

        [UserMapping]
        public Post RequestToEntity(CreatePostRequestModel requestModel)
        {
            return new Post
            {
                Id = Guid.NewGuid(),
                UserId = requestModel.UserId,
                TopicId = requestModel.TopicId,
                Title = requestModel.Title,
                Text = requestModel.Text,
                ImageUrl = requestModel.ImageUrl ?? null,
                IsDeleted = false,
                CreationDate = DateTime.UtcNow
            };
        }
    }
}
