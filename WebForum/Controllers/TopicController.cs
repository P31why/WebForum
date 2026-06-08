using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interface;
using WebForum.Core.Models;

namespace WebForum.WebApi.Controllers
{
    public class TopicController(ITopicService service) : BaseController
    {
        [HttpGet("GetAllFollowedAsync")]
        public async Task<IReadOnlyCollection<FollowedTopicDto>> GetAllFollowedAsync(Guid userId)
        {
            return await service.GetAllFollowedTopicsAsync(userId);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IReadOnlyCollection<TopicShortDto>> GetAllAsync(Guid? userId = null)
        {
            return await service.GetAllShortAsync(userId);
        }

        [HttpGet("GetTopicAsync")]
        public async Task<TopicDto> GetTopicAsync(Guid topicId)
        {
            return await service.GetByIdAsync(topicId);
        }
    }
}
