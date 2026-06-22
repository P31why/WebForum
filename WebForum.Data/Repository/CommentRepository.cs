
using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Infrastructure.Repository
{
    public class CommentRepository(AppDbContext dbContext, CommentMapper mapper) : BaseRepository<long, Comment>(dbContext), ICommentRepository
    {
        public async Task<IReadOnlyCollection<CommentDto>?> GetCollectionDtoAsync(Guid? Id, IdType type)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(c => c.IsDeleted == false);

            if (IdType.User == type)
                query = query.Where(c => c.UserId == Id);
            else
                query = query.Where(c => c.PostId == Id);

            return await query
                .Select(i => mapper.EntityToDto(i))
                .ToListAsync();
        }

        public async Task<CommentDto?> GetDtoAsync(long PostId,  IdType type = IdType.User)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(c => c.Id == PostId)
                .Select(i => mapper.EntityToDto(i))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateEntityAsync(CommentDto commentDto)
        {
            int rows = 0;
            rows = await _dbSet
                .Where(c => c.Id == commentDto.Id && c.PostId == commentDto.PostId)
                .ExecuteUpdateAsync(set =>
                {
                    set.SetProperty(i => i.Text, commentDto.Text);
                    set.SetProperty(i => i.CreationDate, DateTime.UtcNow);
                });

            return rows > 0 ? true : false;
        }
    }
}
