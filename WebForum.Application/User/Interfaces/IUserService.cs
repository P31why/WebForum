
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;

namespace WebForum.Application.User.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto?> GetByIdAsync(Guid userId);

        public Task<UserDto> AddAsync(RegistraitionUserDto dto);

        public Task<string> LoginUserAsync(AuthModel model);

        public Task<bool> UpdateAsync(UpdateUserRequestModel dto);

        public Task<bool> UpdatePasswordAsync(Guid id, string newPawssword);

        public Task<bool> DeleteAsync(Guid userId, DeleteType type);
    }
}
