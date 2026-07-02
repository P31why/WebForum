using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.WebApi.Controllers
{
    public class CommentController(ICommentService service) : BaseController
    {
        [HttpGet(nameof(GetAllAsync))]
        public async Task<IReadOnlyCollection<CommentDto>> GetAllAsync(Guid id, IdType type)
        {
            return await service.GetAllAsync(id, type);
        }

        [HttpPost(nameof(AddAsync))]
        public async Task<CommentDto> AddAsync(CreateCommentRequestModel commentDto)
        {
            return await service.AddAsync(commentDto);
        }

        [HttpPost(nameof(UpdateAync))]
        public async Task<bool> UpdateAync(CommentDto commentDto)
        {
            return await service.UpdateAsync(commentDto);
        }

        [HttpDelete(nameof(DeleteAsync))]
        public async Task<bool> DeleteAsync(long id)
        {
            //TODO: second variant deleting
            return await service.DeleteAsync(id, DeleteType.Full);
        }
    }
}
