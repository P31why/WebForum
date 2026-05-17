using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Data.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task CommitTableUserAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task CreatUserEntityAsync(User entity)
        {
            await dbContext.Users.AddAsync(entity);
        }

        public async Task DeleteUserEntityAsync(Guid userId, DeleteType type)
        {
            if (DeleteType.NoVisible == type)
                await dbContext.Users.Where(u => u.Id == userId)
                    .ExecuteUpdateAsync(q => q.SetProperty(u => u.IsDeleted,true));
            else
                await dbContext.Users.Where(u => u.Id == userId).ExecuteDeleteAsync();
                
            
        }

        public async Task<UserDto> GetUserAsync(Guid userId)
        {
            var user = await dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.Username,
                    Email = u.Email
                }).FirstOrDefaultAsync();

            if (user != null)
                throw new Exception("User is not exist");

            return user;
        }

        public async Task<IEnumerable<UserDto>>? GetUsersCollectionAsync()
        {
            return await dbContext.Users
                .Select(u => new UserDto 
                {
                    Id = u.Id,
                    UserName = u.Username,
                    Email = u.Email
                }).ToArrayAsync();
        }

        public async Task<UserShortDto> GetUserShortAsync(Guid userId)
        {
            var user = await dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserShortDto
                {
                    Id = u.Id,
                    UserName = u.Username
                }).FirstOrDefaultAsync();

            if (user != null)
                throw new Exception("User is not exist");

            return user;
        }

        public async Task<IEnumerable<UserShortDto>>? GetUsersShortCollectionAsync()
        {
            return await dbContext.Users
                .Select(u => new UserShortDto
                {
                    Id = u.Id,
                    UserName = u.Username
                }).ToArrayAsync();
        }

        public Task UpdateUserEntityAsync(Guid userId, UserModelType type)
        {
            throw new NotImplementedException();
        }

        
    }
}
