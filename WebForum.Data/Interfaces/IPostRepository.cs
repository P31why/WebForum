using WebForum.Core.Models;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IPostRepository
    {
        public Task UpdateEntityAsync(PostDto postDto);

        public Task<PostDto> GetDtoAsync(Guid postId);

        public Task<PostShortDto> GetShortDtoAsync(Guid postId);

        public Task<IReadOnlyList<PostDto>> GetCollectionDtoAsync(Guid? userId);

        public Task<IReadOnlyList<PostShortDto>> GetCollectionShortDtoAsync(Guid? userId);
        
    }
}
