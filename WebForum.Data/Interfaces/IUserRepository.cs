
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IUserRepository
    {        
        Task<UserDto> GetDtoAsync(Guid userId);

        Task<UserShortDto> GetShortDtoAsync(Guid userId);

        Task<IEnumerable<UserDto>>? GetCollectionDtoAsync();
        
        Task<IEnumerable<UserShortDto>>? GetCollectionDtoShortAsync();
        
        Task UpdateUserEntityAsync(UserDto userDto, UserModelType type);

        Task UpdateUserPasswordAsync(Guid userId, string hash);

        Task DeleteEntityAsync(Guid userId, DeleteType type);
    }
}
