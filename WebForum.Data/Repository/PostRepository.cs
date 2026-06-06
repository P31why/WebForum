
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

        public async Task<PostDto>? GetDtoAsync(Guid postId)
        {
            var post = await dbContext.Post
                .Where(p => p.Id == postId)
                .Select(i => new PostDto
                {
                    Id= i.Id,
                    Text = i.Text,
                    Title = i.Title,
                    TopicId = i.TopicId,
                    CreationDate = i.CreationDate,
                    UserId = i.UserId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
            
            if (post == null)
                throw new Exception("Post is not exist");

            return post;
        }

        public async Task<PostShortDto>? GetShortDtoAsync(Guid postId)
        {
            var post = await dbContext.Post
                .Where(p => p.Id == postId)
                .Select(i => new PostShortDto
                {
                    Id = i.Id,
                    Title = i.Title,
                    TopicId = i.TopicId,
                    CreationDate = i.CreationDate,
                    UserId = i.UserId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (post == null)
                throw new Exception("Post is not exist");

            return post;
        }

        public async Task<bool> UpdateEntityAsync(PostDto postDto)
        {
            bool isChanged = false;
            await dbContext.Post
                .Where(p => p.Id == postDto.Id)
                .ExecuteUpdateAsync(set =>
                {
                    if (postDto.Title != null)
                    {
                        set.SetProperty(p => p.Title, postDto.Title);
                        isChanged = true;
                    }

                    if (postDto.Text != null)
                    {
                        set.SetProperty(p => p.Text, postDto.Text);
                        isChanged = true;
                    }
                });

            return isChanged;
        }
    }
}
