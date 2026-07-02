
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.Application.User.Interfaces
{
    public interface ICommentService
    {
        public Task<IReadOnlyCollection<CommentDto>> GetAllAsync(Guid postId, IdType type);

        public Task<CommentDto> AddAsync(CreateCommentRequestModel requestModel);

        public Task<bool> UpdateAsync(CommentDto dto);

        public Task<bool> DeleteAsync(long id, DeleteType type);
    }
}
