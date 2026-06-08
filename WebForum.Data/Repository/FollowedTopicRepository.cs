
using Microsoft.EntityFrameworkCore;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class FollowedTopicRepository(AppDbContext dbContext) : BaseRepository<long, FollowedTopic>(dbContext), IFollowedTopicRepository
    {
        public async Task<IReadOnlyCollection<FollowedTopicDto>?> GetAllAsync(Guid userId)
        {
            return (await _dbSet
                .Where(ft => ft.UserId == userId)
                .Select(i => new FollowedTopicDto
                {
                    Id = i.Id,
                    UserId = i.UserId,
                    TopicId = i.TopicId,
                })
                .AsNoTracking()
                .ToListAsync());
        }
    }
}
