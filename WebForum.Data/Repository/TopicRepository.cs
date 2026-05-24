
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
                return await dbContext.Topics.Select(i => new TopicDto
                                             {
                                                 Id = i.Id,
                                                 UserId = i.UserId,
                                                 Title = i.Title,
                                                 Description = i.Description
                                             }).AsNoTracking().ToListAsync();
            }
            else
            {
                return await dbContext.Topics.Where(t => t.UserId == userId)
                                             .Select(i => new TopicDto
                                             {
                                                 Id = i.Id,
                                                 UserId = i.UserId,
                                                 Title = i.Title,
                                                 Description = i.Description
                                             }).AsNoTracking() .ToListAsync();

            }
        }

        public async Task<IReadOnlyCollection<TopicShortDto>> GetCollectionDtoShortAsync(Guid? userId)
        {
            if (userId == null)
            {
                return await dbContext.Topics.Select(i => new TopicShortDto
                                             {
                                                 Id = i.Id,
                                                 Title = i.Title,
                                             }).AsNoTracking().ToListAsync();
            }
            else
            {
                return await dbContext.Topics.Where(t => t.UserId == userId)
                                             .Select(i => new TopicShortDto
                                             {
                                                 Id = i.Id,
                                                 Title = i.Title,
                                             }).AsNoTracking().ToListAsync();

            }
        }

        public Task<TopicDto> GetDtoAsync(Guid topicId)
        {
            throw new NotImplementedException();
        }

        public Task<TopicShortDto> GetShortDtoAsync(Guid topicId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(TopicDto topicDto)
        {
            throw new NotImplementedException();
        }
    }
}
