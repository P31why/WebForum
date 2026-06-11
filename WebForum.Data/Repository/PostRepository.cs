
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Mapper;

namespace WebForum.Infrastructure.Repository
{
    public class PostRepository(AppDbContext dbContext, PostMapper mapper) : BaseRepository<Guid, Post>(dbContext), IPostRepository
    {
        public async Task<IReadOnlyCollection<PostDto>> GetCollectionDtoAsync(Guid Id, IdType type)
        {
            var postQuery = _dbSet
                .AsNoTracking()
                .Where(p => p.IsDeleted == false);

            if(IdType.User == type)
                postQuery = postQuery.Where(p => p.UserId == Id);
            else
                postQuery = postQuery.Where(p => p.TopicId == Id);

            return await postQuery
                .Select(i => mapper.EntityToModel(i))
                .ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<PostShortDto>> GetCollectionShortDtoAsync(Guid Id, IdType type)
        {
            var postQuery = _dbSet
                .AsNoTracking()
                .Where(p => p.IsDeleted == false);

            if (IdType.User == type)
                postQuery = postQuery.Where(p => p.UserId == Id);
            else
                postQuery = postQuery.Where(p => p.TopicId == Id);

            return await postQuery
                .AsNoTracking()
                .Where(p => p.UserId == Id)
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
                .Select(i => mapper.EntityToModel(i))
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
                .Select(i => mapper.EntityToModel(i))
                .FirstOrDefaultAsync();

            if (updatedDto == null)
                throw new Exception("Updated entity not found");

            return updatedDto;
        }

        public override async Task<bool> DeleteEntityAsync(Guid tkey, DeleteType type)
        {
            int rows = 0;
            bool isCompleted = false;

            if (DeleteType.NoVisible == type)
            {
                rows = await _dbSet.Where(p => p.Id == tkey)
                    .ExecuteUpdateAsync(set => set.SetProperty(i => i.IsDeleted, true));

                isCompleted = rows > 0 ? true : false;
            }
            else
                isCompleted = await base.DeleteEntityAsync(tkey, type);

            return isCompleted;
        }
    }
}
