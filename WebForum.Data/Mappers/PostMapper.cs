
using Riok.Mapperly.Abstractions;
using WebForum.Core.Models;
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
    }
}
