
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task CreatUserEntityAsync(User entity);
        
        Task<UserDto> GetUserAsync(Guid userId);

        Task<UserShortDto> GetUserShortAsync(Guid userId);

        Task<IEnumerable<UserDto>>? GetUsersCollectionAsync();
        
        Task<IEnumerable<UserShortDto>> GetUsersShortCollectionAsync();
        
        Task UpdateUserEntityAsync(UserDto userDto, UserModelType type);

        Task UpdateUserPasswordAsync(Guid userId, string hash);

        Task DeleteUserEntityAsync(Guid userId, DeleteType type);

        Task CommitTableUserAsync();
    }
}
