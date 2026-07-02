
using Microsoft.EntityFrameworkCore;
using System.Data;
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
            var query = _dbSet
                .AsNoTracking()
                .Where(t => t.IsDeleted == false);

            if (userId != null)
                query = query.Where(t => t.UserId == userId);

            return await query
                .Select(i => mapper.EntityToDto(i))
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<TopicShortDto>> GetCollectionShortDtoAsync(Guid? userId)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(t => t.IsDeleted == false);

            if (userId != null)
                query.Where(t => t.UserId == userId);

            return await query
                .Select(i => new TopicShortDto
                {
                    Id = i.Id,
                    Title = i.Title,
                })
                .ToListAsync();
        }

        //TODO: убрать возврат исключений
        public async Task<TopicDto> GetDtoAsync(Guid topicId)
        {
            var topic = await _dbSet
                .AsNoTracking()
                .Where(t => t.Id == topicId && t.IsDeleted == false)
                .Select(i => mapper.EntityToDto(i))
                .FirstOrDefaultAsync();

            if (topic == null)
                throw new Exception("This topic does not exist");

            return topic;
        }

        public async Task<bool> GetSameNameTopic(string name)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(t => t.Title == name)
                .FirstOrDefaultAsync() != null;
        }

        public async Task<TopicShortDto> GetShortDtoAsync(Guid topicId)
        {
            var topic = await _dbSet
                .AsNoTracking()
                .Where(t => t.Id == topicId && t.IsDeleted == false)
                .Select(i => new TopicShortDto
                {
                    Id = i.Id,
                    Title = i.Title,
                }).FirstOrDefaultAsync();

            if (topic == null)
                throw new Exception("This topic does not exist");

            return topic;
        }

        public async Task<bool> UpdateEntityAsync(TopicDto topicDto)
        {
            return await _dbSet
                .Where(t => t.Id == topicDto.Id && t.IsDeleted == false)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(t => t.Title, topicDto.Title)
                    .SetProperty(t => t.Description, topicDto.Description)
                ) > 0;
        }
    }
}
