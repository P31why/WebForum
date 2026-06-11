
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

        public async Task<bool> DeletePostAsync(Guid topicId, DeleteType type = DeleteType.NoVisible)
        {
            return await repository.DeleteEntityAsync(topicId, type);
        }

        public async Task<IReadOnlyCollection<PostDto>> GetAllAsync(Guid topicId, IdType type)
        {
            return await repository.GetCollectionDtoAsync(topicId, type);
        }

        public async Task<IReadOnlyCollection<PostShortDto>> GetAllShortAsync(Guid topicId, IdType type)
        {
            return await repository.GetCollectionShortDtoAsync(topicId, type);
        }

        public Task<PostDto> GetByIdAsync(Guid postId)
        {
            return repository.GetDtoAsync(postId);
        }

        public async Task<PostDto> UpdatePostAsync(PostDto postDto)
        {
            return await repository.UpdateEntityAsync(postDto);
        }
    }
}
