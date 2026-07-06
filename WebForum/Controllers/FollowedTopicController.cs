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
        [HttpPost(nameof(AddAsync))]
        public async Task<FollowedTopicDto> AddAsync(FollowedTopicDto dto)
        {
            return await service.AddAsync(dto);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IReadOnlyCollection<FollowedTopicDto>> GetAll(Guid userId)
        {
            return await service.GetAllFollowedTopicsAsync(userId);
        }

        [HttpDelete(nameof(DeleteAsync))]
        public async Task<bool> DeleteAsync(Guid? userId, DeleteType type, long followTopicId)
        {
            return await service.DeleteAsync(followTopicId, type);
        }
}
}
