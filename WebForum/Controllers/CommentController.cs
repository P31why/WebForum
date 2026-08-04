using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.WebApi.Controllers
{
    public class CommentController(ICommentService service) : BaseController
    {
        [HttpGet("comments")]
        public async Task<IActionResult> GetAllAsync(Guid id, IdType type)
        {
            IReadOnlyCollection<CommentDto> models= await service.GetAllAsync(id, type);

            if (models == null)
                return NotFound();

            return Ok(models);
        }

        [HttpPost(nameof(AddAsync))]
        public async Task<IActionResult> AddAsync(CreateCommentRequestModel commentDto)
        {
            CommentDto model = await service.AddAsync(commentDto);

            if(model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost(nameof(UpdateAync))]
        public async Task<IActionResult> UpdateAync(UpdateCommentRequestModel commentDto)
        {
            bool isUpdated = await service.UpdateAsync(commentDto);

            if(!isUpdated)
                return NotFound();

            return Ok();
        }

        [HttpDelete(nameof(DeleteAsync))]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            bool isDeleted = await service.DeleteAsync(id, DeleteType.Full);

            if(!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
