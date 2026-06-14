
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
            IReadOnlyCollection<CommentDto> comments;
            if (IdType.User == type)
            {
                comments = await _dbSet
                    .AsNoTracking()
                    .Where(c => c.UserId == Id)
                    .Select(i => mapper.EntityToDto(i))
                    .ToListAsync();
            }
            else
            {
                comments = await _dbSet
                    .AsNoTracking()
                    .Where(c => c.PostId == Id)
                    .Select(i => mapper.EntityToDto(i))
                    .ToListAsync();
            }
                
            return comments;
        }

        public Task<CommentDto?> GetDtoAsync(long PostId,  IdType type = IdType.User)
        {
            /*return dbContext.Comment
                .Where(c => c.Id == PostId)
                .Select(i => new CommentDto 
                { 
                    Id = i.Id, 
                    PostId = i.PostId, 
                    UserId = i.UserId, 
                    Text = i.Text, 
                    CreationDate = i.CreationDate, 
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();*/
            throw new NotImplementedException();
        }

        public async Task<CommentDto> UpdateEntityAsync(CommentDto commentDto)
        {
            int rowsUpdated  = await _dbSet
                .Where(c => c.Id == commentDto.Id && c.PostId == commentDto.PostId)
                .ExecuteUpdateAsync(set =>
                {
                    if (commentDto.Text != null)
                    {
                        set.SetProperty(i => i.Text, commentDto.Text);
                        set.SetProperty(i => i.CreationDate, DateTime.UtcNow);
                    }
                });

            if (rowsUpdated == 0)
                throw new Exception("Error with update entity");

            var updatedDto = await _dbSet
                .AsNoTracking()
                .Where(p => p.Id == commentDto.Id)
                .Select(i => mapper.EntityToDto(i))
                .FirstOrDefaultAsync();

            if (updatedDto == null)
                throw new Exception("Updated entity not found");

            return updatedDto;
        }
    }
}
