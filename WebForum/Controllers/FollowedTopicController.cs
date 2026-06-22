using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.WebApi.Controllers
{
    public class FollowedTopicController(IFollowTopicService service) : BaseController
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
            // TODO: second delete variant
            return await service.DeleteAsync(followTopicId, type);
        }
}
}
