
using Microsoft.EntityFrameworkCore;
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
        public async Task<IReadOnlyCollection<PostDto>?> GetCollectionDtoAsync(Guid Id, IdType type)
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

        public async Task<IReadOnlyCollection<PostShortDto>?> GetCollectionShortDtoAsync(Guid Id, IdType type)
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
                .Select(i => mapper.EntitytoShortDto(i))
                .ToArrayAsync();
        }

        public async Task<PostDto> GetDtoAsync(Guid postId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(p => p.Id == postId && p.IsDeleted == false)
                .Select(i => mapper.EntityToModel(i))
                .FirstOrDefaultAsync() ?? throw new Exception("Post is not exist");
        }

        public async Task<PostShortDto> GetShortDtoAsync(Guid postId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(p => p.Id == postId && p.IsDeleted == false)
                .Select(i => mapper.EntitytoShortDto(i))
                .FirstOrDefaultAsync() ?? throw new Exception("Post is not exist");
        }

        public async Task<bool> UpdateEntityAsync(PostDto postDto)
        {
            int rows = 0;
            rows= await _dbSet
                .Where(p => p.Id == postDto.Id && p.IsDeleted == false)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(p => p.Title, postDto.Title)
                    .SetProperty(p => p.Text, postDto.Text)
                );
            return rows > 0;
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
