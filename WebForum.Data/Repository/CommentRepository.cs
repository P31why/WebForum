
using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class CommentRepository(AppDbContext dbContext) : BaseRepository<long, Comment>(dbContext), ICommentRepository
    {
        public async Task<IReadOnlyCollection<CommentDto>>? GetCollectionDtoAsync(Guid? Id, IdType type)
        {
            IReadOnlyCollection<CommentDto> comments;
            if (IdType.User == type)
            {
                comments = await _dbSet
                    .Where(c => c.UserId == Id)
                    .Select(i => new CommentDto
                    {
                        Id = i.Id,
                        PostId = i.PostId,
                        UserId = i.UserId,
                        Text = i.Text,
                        CreationDate = i.CreationDate,
                    })
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                comments = await _dbSet
                    .Where(c => c.PostId == Id)
                    .Select(i => new CommentDto
                    {
                        Id = i.Id,
                        PostId = i.PostId,
                        UserId = i.UserId,
                        Text = i.Text,
                        CreationDate = i.CreationDate,
                    })
                    .AsNoTracking()
                    .ToListAsync();
            }
                
            return comments;
        }

        public Task<CommentDto>? GetDtoAsync(Guid PostId,  IdType type = IdType.User)
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

        public async Task<bool> UpdateEntityAsync(CommentDto commentDto)
        {
            bool isChanged = false;
            
            await _dbSet
                .Where(c => c.Id == commentDto.Id && c.PostId == commentDto.PostId)
                .ExecuteUpdateAsync(set =>
                {
                    if (commentDto.Text != null)
                    {
                        set.SetProperty(i => i.Text, commentDto.Text);
                        set.SetProperty(i => i.CreationDate, DateTime.UtcNow);
                        isChanged = true;
                    }
                });

            return isChanged;
        }
    }
}
