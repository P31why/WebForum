
using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Infrastructure.Repository
{
    public class FollowedTopicRepository(AppDbContext dbContext,
                                        FollowedTopicsMapper mapper) : BaseRepository<long, FollowedTopic>(dbContext), IFollowedTopicRepository
    {
        public async Task<FollowedTopicDto?> GetByIdAsync(long id)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(ft => ft.Id == id)
                .Select(i => mapper.EntityToDto(i))
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<FollowedTopicDto>?> GetAllAsync(Guid userId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(ft => ft.UserId == userId)
                .Select(i => mapper.EntityToDto(i))
                .ToListAsync();
        }

        public override async Task<bool> DeleteEntityAsync(long tkey, DeleteType type)
        {
            if (DeleteType.NoVisible == type)
            {
                return await _dbSet
                    .AsNoTracking()
                    .Where(ft => ft.Id == tkey)
                    .Select(ft => mapper.EntityToDto(ft))
                    .ExecuteUpdateAsync(set => set.SetProperty(i => i.IsDeleted, true)) > 0;
            }

            return await base.DeleteEntityAsync(tkey, type);
        }
    }
}
