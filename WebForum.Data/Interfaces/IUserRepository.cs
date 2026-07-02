
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<Guid, User>
    {
        Task<UserDto?> GetDtoAsync(Guid userId);

        Task<LoginDto?> GetLoginDtoByNameAsync(string name);

        Task<bool> UserExistByNameAsync(string name);

        Task<bool> UserExistByEmailAsync(string email);

        Task<UserShortDto?> GetShortDtoAsync(Guid userId);

        Task<IReadOnlyCollection<UserDto>?> GetCollectionDtoAsync();
        
        Task<IReadOnlyCollection<UserShortDto>?> GetCollectionShortDtoAsync();
        
        Task<bool> UpdateUserEntityAsync(UserDto userDto, UserModelType type);

        Task<bool> UpdateUserPasswordAsync(Guid userId, string hash);
    }
}
