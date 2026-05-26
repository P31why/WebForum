
using Microsoft.EntityFrameworkCore;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class PostRepository(AppDbContext dbContext) : BaseRepository<Guid, Post>(dbContext), IPostRepository
    {
        public Task<IReadOnlyList<PostDto>> GetCollectionDtoAsync(Guid? userId)
        {
            return dbContext.Post
                .Where(p => p.UserId == userId)
                .Select(i => new PostDto
                {
                    Id = i.Id,
                    TopicId = i.TopicId,

                })
        }

        public Task<IReadOnlyList<PostShortDto>> GetCollectionShortDtoAsync(Guid? userId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetDtoAsync(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostShortDto> GetShortDtoAsync(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(PostDto postDto)
        {
            throw new NotImplementedException();
        }
    }
}
