
using Microsoft.EntityFrameworkCore;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class TopicRepository(AppDbContext dbContext) : BaseRepository<Guid, Topic>(dbContext), ITopicRepository
    {
        public async Task<IReadOnlyCollection<TopicDto>> GetCollectionDtoAsync(Guid? userId)
        {
            if(userId == null)
            {
                return await _dbSet
                    .Select(i => new TopicDto
                    {
                        Id = i.Id,
                        UserId = i.UserId,
                        Title = i.Title,
                        Description = i.Description
                    }).AsNoTracking().ToListAsync();
            }
            else
            {
                return await _dbSet
                    .Where(t => t.UserId == userId)
                    .Select(i => new TopicDto
                    {
                        Id = i.Id,
                        UserId = i.UserId,
                        Title = i.Title,
                        Description = i.Description
                    }).AsNoTracking().ToListAsync();

            }
        }

        public async Task<IReadOnlyCollection<TopicShortDto>> GetCollectionShortDtoAsync(Guid? userId)
        {
            if (userId == null)
            {
                return await _dbSet
                    .Select(i => new TopicShortDto
                    {
                        Id = i.Id,
                        Title = i.Title,
                    }).AsNoTracking().ToListAsync();
            }
            else
            {
                return await _dbSet
                    .Where(t => t.UserId == userId)
                    .Select(i => new TopicShortDto
                    {
                        Id = i.Id,
                        Title = i.Title,
                    }).AsNoTracking().ToListAsync();
            }
        }

        public async Task<TopicDto> GetDtoAsync(Guid topicId)
        {
            var topic = await _dbSet
                .Where(t => t.Id == topicId)
                .Select(i => new TopicDto
                {
                    Id = i.Id,
                    UserId = i.UserId,
                    Title = i.Title,
                    Description = i.Description
                }).AsNoTracking().FirstOrDefaultAsync();

            if (topic == null)
                throw new Exception("This topic does not exist");

            return topic;
        }

        public async Task<TopicShortDto> GetShortDtoAsync(Guid topicId)
        {
            var topic = await _dbSet
                .Where(t => t.Id == topicId)
                .Select(i => new TopicShortDto
                {
                    Id = i.Id,
                    Title = i.Title,
                }).AsNoTracking().FirstOrDefaultAsync();

            if (topic == null)
                throw new Exception("This topic does not exist");

            return topic;
        }

        public Task UpdateEntityAsync(TopicDto topicDto)
        {
            return _dbSet
                .Where(t => t.Id == topicDto.Id)
                .ExecuteUpdateAsync(set =>
                {
                    if (topicDto.Title != null)
                        set.SetProperty(i => i.Title, topicDto.Title);

                    if (topicDto.Description != null)
                        set.SetProperty(i => i.Description, topicDto.Description);
                });
        }
    }
}
