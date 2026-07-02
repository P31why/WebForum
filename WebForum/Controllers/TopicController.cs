using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interface;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.WebApi.Controllers
{
    public class TopicController(ITopicService service) : BaseController
    {
        [Authorize]
        [HttpPost(nameof(AddAsync))]
        public async Task<TopicDto> AddAsync(CreateTopicRequestModel topic)
        {
            return await service.AddAsync(topic);
        }  

        //TODO: решить как авторизовывать
        [HttpGet(nameof(GetAllAsync))]
        public async Task<IReadOnlyCollection<TopicShortDto>> GetAllAsync(Guid userId)
        {
            return await service.GetAllShortAsync(userId);
        }

        [HttpGet(nameof(GetAllMainAsync))]
        public async Task<IReadOnlyCollection<TopicShortDto>> GetAllMainAsync()
        {
            return await service.GetAllShortAsync(null);
        }

        [HttpGet(nameof(GetTopicAsync))]
        public async Task<TopicDto> GetTopicAsync(Guid topicId)
        {
            return await service.GetByIdAsync(topicId);
        }

        [Authorize]
        [HttpPost(nameof(UpdateAsync))]
        public async Task<bool> UpdateAsync(TopicDto dto)
        {
            return await service.UpdateAsync(dto);
        }
    }
}
