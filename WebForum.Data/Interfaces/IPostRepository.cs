using WebForum.Core.Models;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IPostRepository : IBaseRepository<Guid,Post>
    {
        public Task<PostDto> UpdateEntityAsync(PostDto postDto);

        public Task<PostDto>? GetDtoAsync(Guid postId);

        public Task<PostShortDto>? GetShortDtoAsync(Guid postId);

        public Task<IReadOnlyCollection<PostDto>>? GetCollectionDtoAsync(Guid? userId);

        public Task<IReadOnlyCollection<PostShortDto>>? GetCollectionShortDtoAsync(Guid? userId);
        
    }
}
