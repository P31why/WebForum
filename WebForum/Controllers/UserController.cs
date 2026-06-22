using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.WebApi.Controllers
{
    public class UserController(IUserService service) : BaseController
    {
        [HttpPost(nameof(AddAsync))]
        public async Task<UserDto> AddAsync(UserDto dto)
        {
            return await service.AddAsync(dto);
        }

        [HttpGet(nameof(GetById))]
        public async Task<UserDto> GetById(Guid userId)
        {
            return await service.GetByIdAsync(userId);
        }

        [HttpPost(nameof(UpdateAsync))]
        public async Task<bool> UpdateAsync(UserDto dto)
        {
            return await service.UpdateAsync(dto);
        }

        public async Task<bool> UpdatePassword(Guid id, string password)
        {
            return await service.UpdatePasswordAsync(id, password);
        }

        [HttpDelete(nameof(DeleteAsync))]
        public async Task<bool> DeleteAsync(Guid id, DeleteType type)
        {
            return await service.DeleteAsync(id, type);
        }
    }
}
