using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.WebApi.Controllers
{
    public class PostController(IPostService service) : BaseController
    {
        [HttpGet(nameof(GetAllAsync))]
        public async Task<IReadOnlyCollection<PostShortDto>> GetAllAsync(Guid id, IdType type)
        {
            return await service.GetAllShortAsync(id, type);
        }

        [HttpGet(nameof(GetByIdAync))]
        public async Task<PostDto> GetByIdAync(Guid id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost(nameof(AddAsync))]
        public async Task<PostDto> AddAsync(CreatePostRequestModel dto)
        {
            return await service.AddPostAsync(dto);
        }

        [HttpPost(nameof(UpdateAsync))]
        public async Task<bool> UpdateAsync(PostDto dto)
        {
            return await service.UpdatePostAsync(dto);
        }

        [HttpDelete(nameof(DeleteAsync))]
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await service.DeletePostAsync(id);
        }
    }
}
