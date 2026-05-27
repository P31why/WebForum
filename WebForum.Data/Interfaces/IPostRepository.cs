using WebForum.Core.Models;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IPostRepository
    {
        public Task UpdateEntityAsync(PostDto postDto);

        public Task<PostDto> GetDtoAsync(Guid postId);

        public Task<PostShortDto> GetShortDtoAsync(Guid postId);

        public Task<IReadOnlyCollection<PostDto>>? GetCollectionDtoAsync(Guid? userId);

        public Task<IReadOnlyCollection<PostShortDto>>? GetCollectionShortDtoAsync(Guid? userId);
        
    }
}
