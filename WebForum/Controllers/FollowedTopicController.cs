using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.WebApi.Controllers
{
    [Authorize]
    public class FollowedTopicController(IFollowedTopicService service) : BaseController
    {
        [HttpPost("follwed-topics")]
        public async Task<IActionResult> AddAsync(FollowedTopicDto dto)
        {
            var model = await service.AddUserFollowedTopicAsync(dto);

            if(model == null)
                return NotFound();

            return CreatedAtAction(nameof(GetByIdAsync),model);
        }

        [HttpGet("follwed-topics/{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var model = service.GetUserFollowedTopicByIdAsync(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpGet("follwed-topics")]
        public async Task<IActionResult> GetAllAsync(Guid userId)
        {
            var models = await service.GetUserFollowedTopicsAsync(userId);
            
            if (models == null)
                return NotFound();

            return Ok(models);
        }

        [HttpDelete("follwed-topics")]
        public async Task<IActionResult> DeleteAsync(Guid? userId, DeleteType type, long followTopicId)
        {
            var isDeleted = await service.DeleteUserFollowedTopicAsync(followTopicId, type);

            if (isDeleted)
                return NotFound();

            return Ok();
        }
}
}
