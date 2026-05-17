using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Data.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task CreatUserEntityAsync(User entity)
        {
            await dbContext.Users.AddAsync(entity);
        }

        public async Task GetAllUsersAsync(Guid userId, UserModelType type)
        {
            IQueryable<User> query = dbContext.Users.Where(e => e.Id == userId);

            if (type == UserModelType.Short)
                query = query.Select(u => new User { u.Id, u.Username });
        }

        public async Task UpdateUserEntityAsync(Guid userId, UserModelType type)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserEntityAsync(Guid userId, DeleteType type)
        {
            throw new NotImplementedException();
        }
    }
}
