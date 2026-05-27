
using Microsoft.EntityFrameworkCore;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class PostRepository(AppDbContext dbContext) : BaseRepository<Guid, Post>(dbContext), IPostRepository
    {
        public async Task<IReadOnlyCollection<PostDto>>? GetCollectionDtoAsync(Guid? userId)
        {
            return await dbContext.Post
                .Where(p => p.UserId == userId)
                .Select(i => new PostDto
                {
                    Id = i.Id,
                    UserId = i.UserId,
                    TopicId = i.TopicId,
                    Title = i.Title,
                    CreationDate = i.CreationDate,
                    Text = i.Text,
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<PostShortDto>>? GetCollectionShortDtoAsync(Guid? userId)
        {
            return await dbContext.Post
                .Where(p => p.UserId == userId)
                .Select(i => new PostShortDto
                {
                    Id = i.Id,
                    UserId = i.UserId,
                    TopicId = i.TopicId,
                    Title = i.Title,
                    CreationDate = i.CreationDate
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PostDto> GetDtoAsync(Guid postId)
        {
            var post = dbContext.Post.Where(Guid)

            return 
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
