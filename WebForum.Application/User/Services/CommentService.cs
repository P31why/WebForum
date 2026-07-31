
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Application.User.Services
{
    public class CommentService(ICommentRepository repository, CommentMapper mapper) : ICommentService
    {
        public async Task<CommentDto> AddAsync(CreateCommentRequestModel requestModel)
        {
            var entity = await repository.CreateEntityAsync(mapper.RequestToEntity(requestModel));

            bool isCreated = await repository.CommitDbAsync();

            if (!isCreated)
                throw new Exception("Error with creating comment");

            return mapper.EntityToDto(entity);
        }

        public async Task<bool> DeleteAsync(long id, DeleteType type = DeleteType.Full)
        {
            //TODO: second deleting variant
            return await repository.DeleteEntityAsync(id, type);
        }

        public async Task<IReadOnlyCollection<CommentDto>> GetAllAsync(Guid postId, IdType type = IdType.Entity)
        {
            return await repository.GetCollectionDtoAsync(postId, type) ?? Array.Empty<CommentDto>();
        }

        public async Task<bool> UpdateAsync(UpdateCommentRequestModel dto)
        {
            return await repository.UpdateEntityAsync(dto);
        }
    }
}
