
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<Guid, User>
    {
        Task<UserDto> AddNewUser(RegistraitionUserDto dto);

        Task<UserDto?> GetDtoAsync(Guid userId);

        Task<UserShortDto?> GetShortDtoAsync(Guid userId);

        Task<IReadOnlyCollection<UserDto>?> GetCollectionDtoAsync();
        
        Task<IReadOnlyCollection<UserShortDto>?> GetCollectionShortDtoAsync();
        
        Task<bool> UpdateUserEntityAsync(UserDto userDto, UserModelType type);

        Task<bool> UpdateUserPasswordAsync(Guid userId, string hash);
    }
}
