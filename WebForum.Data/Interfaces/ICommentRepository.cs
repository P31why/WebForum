
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.Infrastructure.Interfaces
{
    public interface ICommentRepository
    {
        public Task<bool> UpdateEntityAsync(CommentDto commentDto);

        public Task<CommentDto>? GetDtoAsync(Guid Id, IdType type);

        public Task<IReadOnlyCollection<CommentDto>>? GetCollectionDtoAsync(Guid? Id, IdType type);
    }
}
