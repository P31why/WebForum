
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.Application.User.Interfaces
{
    public interface ICommentService
    {
        public Task<IReadOnlyCollection<CommentDto>> GetAllAsync(Guid postId, IdType type);

        public Task<CommentDto> AddAsync(CommentDto dto);

        public Task<bool> UpdateAsync(CommentDto dto);

        public Task<bool> DeleteAsync(long id, DeleteType type);
    }
}
