using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.WebApi.Controllers
{
    public class UserController(IUserService service) : BaseController
    {
        [HttpPost(nameof(AddAsync))]
        public async Task<IResult> AddAsync(RegistraitionUserDto dto)
        {
            return Results.Ok(await service.AddAsync(dto));
        }

        [HttpPost(nameof(Login))]
        public async Task<IResult> Login(AuthModel authModel)
        {
            var token = await service.LoginUserAsync(authModel);

            return Results.Ok(token);
        }

        [HttpGet(nameof(GetById))]
        public async Task<UserDto?> GetById(Guid userId)
        {
            return await service.GetByIdAsync(userId);
        }

        [Authorize]
        [HttpPost(nameof(UpdateAsync))]
        public async Task<bool> UpdateAsync(UpdateUserRequestModel dto)
        {
            return await service.UpdateAsync(dto);
        }

        [Authorize]
        [HttpPost(nameof(UpdatePassword))]
        public async Task<bool> UpdatePassword(Guid id, string password)
        {
            return await service.UpdatePasswordAsync(id, password);
        }

        [Authorize]
        [HttpDelete(nameof(DeleteAsync))]
        public async Task<bool> DeleteAsync(Guid id, DeleteType type)
        {
            return await service.DeleteAsync(id, type);
        }
    }
}
