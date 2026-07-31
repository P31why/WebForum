
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface ICommentRepository : IBaseRepository<long, Comment>
    {
        public Task<bool> UpdateEntityAsync(UpdateCommentRequestModel commentDto);

        public Task<CommentDto?> GetDtoAsync(long Id, IdType type);

        public Task<IReadOnlyCollection<CommentDto>?> GetCollectionDtoAsync(Guid? Id, IdType type);
    }
}
