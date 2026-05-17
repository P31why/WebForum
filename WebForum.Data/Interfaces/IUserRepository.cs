
using WebForum.Core;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task CreatUserEntityAsync(User entity);
        
        Task GetAllUsersAsync(Guid userId, UserModelType type);
        
        Task UpdateUserEntityAsync(Guid userId, UserModelType type);

        Task DeleteUserEntityAsync(Guid userId, DeleteType type);
    }
}
