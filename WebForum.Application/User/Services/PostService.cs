
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Application.User.Services
{
    public class PostService(IPostRepository repository) : IPostService
    {
        public Task<PostDto> AddPostAsync(PostDto postDto)
        {
            //repository.CreateEntityAsync();
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(Guid topicId, DeleteType type = DeleteType.NoVisible)
        {
            throw new NotImplementedException();
        }

        public Task<PostShortDto> GetAllShortAsync(Guid topicId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetByIdAsync(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePostAsync(PostDto postDto)
        {
            throw new NotImplementedException();
        }
    }
}
