using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interface;
using WebForum.Core.Models;

namespace WebForum.WebApi.Controllers
{
    public class TopicController(ITopicService service) : BaseController
    {
        [HttpPost(nameof(AddAsync))]
        public async Task<TopicDto> AddAsync(TopicDto topic)
        {
            return await service.AddAsync(topic);
        }  

        [HttpGet(nameof(GetAllAsync))]
        public async Task<IReadOnlyCollection<TopicShortDto>> GetAllAsync(Guid? userId = null)
        {
            return await service.GetAllShortAsync(userId);
        }

        [HttpGet(nameof(GetTopicAsync))]
        public async Task<TopicDto> GetTopicAsync(Guid topicId)
        {
            return await service.GetByIdAsync(topicId);
        }

        [HttpPost(nameof(UpdateAsync))]
        public async Task<bool> UpdateAsync(TopicDto dto)
        {
            return await service.UpdateAsync(dto);
        }
    }
}
