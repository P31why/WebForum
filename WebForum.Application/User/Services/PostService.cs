
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Infrastructure.Interfaces;
using WebForum.Mapper;

namespace WebForum.Application.User.Services
{
    public class PostService(IPostRepository repository, PostMapper mapper) : IPostService
    {
        public async Task<PostDto> AddPostAsync(PostDto postDto)
        {
            var entity = await repository.CreateEntityAsync(mapper.ModelToEntityCreate(postDto));
            
            bool isCreated = await repository.CommitDbAsync();

            if (!isCreated)
                throw new Exception("Error creating post");

            return mapper.EntityToModel(entity);
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

        public async Task<PostDto> UpdatePostAsync(PostDto postDto)
        {
            await repository.UpdateEntityAsync(postDto);
        }
    }
}
