
using WebForum.Core;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IUserRepository<TKey>
    {
        Task CreatUserEntityAsync();
        
        Task GetAllUsersAsync(TKey userId, UserGetInfo type);
        
        Task UpdateUserEntityAsync();

        Task DeleteUserEntityAsync(TKey userId);
    }
}
