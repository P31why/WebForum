
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.Application.User.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetByIdAsync(Guid userId);

        public Task<UserDto> AddAsync(UserDto dto);

        public Task<bool> UpdateAsync(UserDto dto);

        public Task<bool> UpdatePasswordAsync(Guid id, string hash);

        public Task<bool> DeleteAsync(Guid userId, DeleteType type);
    }
}
