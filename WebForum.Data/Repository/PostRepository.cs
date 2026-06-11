
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class PostRepository(AppDbContext dbContext) : BaseRepository<Guid, Post>(dbContext), IPostRepository
    {
        public async Task<IReadOnlyCollection<PostDto>> GetCollectionDtoAsync(Guid? userId = null)
        {
            var postQuery = _dbSet.AsNoTracking();

            if(userId != null)
                postQuery = postQuery.Where(p => p.UserId == userId);

            return await postQuery
                .Select(i => new PostDto
                {
                    Id = i.Id,
                    UserId = i.UserId,
                    TopicId = i.TopicId,
                    Title = i.Title,
                    IsDeleted = i.IsDeleted,
                    CreationDate = i.CreationDate,
                    Text = i.Text,
                })
                .ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<PostShortDto>> GetCollectionShortDtoAsync(Guid? userId)
        {
            var postQuery = _dbSet.AsNoTracking();

            if (userId != null)
                postQuery = postQuery.Where(p => p.UserId == userId);

            return await postQuery
                .AsNoTracking()
                .Where(p => p.UserId == userId)
                .Select(i => new PostShortDto
                {
                    Id = i.Id,
                    UserId = i.UserId,
                    TopicId = i.TopicId,
                    Title = i.Title,
                    IsDeleted = i.IsDeleted,
                    CreationDate = i.CreationDate
                })
                .ToArrayAsync();
        }

        public async Task<PostDto> GetDtoAsync(Guid postId)
        {
            var post = await _dbSet
                .AsNoTracking()
                .Where(p => p.Id == postId)
                .Select(i => new PostDto
                {
                    Id= i.Id,
                    Text = i.Text,
                    Title = i.Title,
                    TopicId = i.TopicId,
                    IsDeleted= i.IsDeleted,
                    CreationDate = i.CreationDate,
                    UserId = i.UserId
                })
                .FirstOrDefaultAsync();
            
            if (post == null)
                throw new Exception("Post is not exist");

            return post;
        }

        public async Task<PostShortDto> GetShortDtoAsync(Guid postId)
        {
            var post = await _dbSet
                .AsNoTracking()
                .Where(p => p.Id == postId)
                .Select(i => new PostShortDto
                {
                    Id = i.Id,
                    Title = i.Title,
                    TopicId = i.TopicId,
                    IsDeleted = i.IsDeleted,
                    CreationDate = i.CreationDate,
                    UserId = i.UserId
                })
                .FirstOrDefaultAsync();

            if (post == null)
                throw new Exception("Post is not exist");

            return post;
        }

        public async Task<PostDto> UpdateEntityAsync(PostDto postDto)
        {
            int rowsUpdated = await _dbSet
                .Where(p => p.Id == postDto.Id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(p => p.Title, postDto.Title)
                    .SetProperty(p => p.Text, postDto.Text)
                );

            if (rowsUpdated == 0)
                throw new Exception("Error with update entity");

            var updatedDto = await _dbSet
                .AsNoTracking()
                .Where(p => p.Id == postDto.Id)
                .Select(i => new PostDto
                {
                    Id = i.Id,
                    Text = i.Text,
                    Title = i.Title,
                    TopicId = i.TopicId,
                    IsDeleted = i.IsDeleted,
                    CreationDate = i.CreationDate,
                    UserId = i.UserId
                }).FirstOrDefaultAsync();

            if (updatedDto == null)
                throw new Exception("Updated entity not found");

            return updatedDto;
        }

        public override async Task DeleteEntityAsync(Guid tkey, DeleteType type)
        {
            if (DeleteType.NoVisible == type)
                await _dbSet.Where(p => p.Id == tkey)
                    .ExecuteUpdateAsync(set => set.SetProperty(i => i.IsDeleted, true));
            else
                await base.DeleteEntityAsync(tkey, type);
        }
    }
}
