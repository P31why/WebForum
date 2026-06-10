
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
                TopicId = dto.TopicId,

                UserId = dto.UserId,

                Title = dto.Title,

                Text = dto.Text,

                IsDeleted = false
            };
        }

        [UserMapping]
        public PostDto EntityToModel(Post entity)
        {
            return new PostDto
            {
                TopicId = entity.TopicId,

                UserId = entity.UserId,

                Title = entity.Title,

                Text = entity.Text,

                IsDeleted = entity.IsDeleted,
            };
        }
    }
}
