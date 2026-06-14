
using Microsoft.EntityFrameworkCore;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Infrastructure.Repository
{
    public class TopicRepository(AppDbContext dbContext, TopicMapper mapper) : BaseRepository<Guid, Topic>(dbContext), ITopicRepository
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

        public async Task<TopicDto> UpdateEntityAsync(TopicDto topicDto)
        {
            int rowsUpdated = await _dbSet
                .Where(t => t.Id == topicDto.Id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(t => t.Title, topicDto.Title)
                    .SetProperty(t => t.Description, topicDto.Description)
                );

            if (rowsUpdated == 0)
                throw new Exception("Error with update entity");

            var updatedDto = await _dbSet
                .AsNoTracking()
                .Where(p => p.Id == topicDto.Id)
                .Select(i => mapper.EntityToDto(i))
                .FirstOrDefaultAsync();

            if (updatedDto == null)
                throw new Exception("Updated entity not found");

            return updatedDto;
        }
    }
}
