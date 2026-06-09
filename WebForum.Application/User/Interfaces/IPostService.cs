
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.Application.User.Interfaces
{
    public interface IPostService
    {
        public Task<PostShortDto> GetAllShortAsync(Guid topicId);

        public Task<PostDto> GetByIdAsync(Guid postId);

        public Task<PostDto> AddPostAsync(PostDto postDto);

        public Task<bool> UpdatePostAsync (PostDto postDto);

        public Task<bool> DeletePostAsync (Guid topicId, DeleteType type = DeleteType.NoVisible);
    }
}
