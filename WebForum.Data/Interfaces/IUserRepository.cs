
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<Guid, User>
    {        
        Task<UserDto> GetDtoAsync(Guid userId);

        Task<UserShortDto> GetShortDtoAsync(Guid userId);

        Task<IEnumerable<UserDto>>? GetCollectionDtoAsync();
        
        Task<IEnumerable<UserShortDto>>? GetCollectionShortDtoAsync();
        
        Task<bool> UpdateUserEntityAsync(UserDto userDto, UserModelType type);

        Task<bool> UpdateUserPasswordAsync(Guid userId, string hash);
    }
}
