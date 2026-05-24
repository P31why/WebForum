using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Data;
using WebForum.Data.Entities;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class UserRepository(AppDbContext dbContext) : BaseRepository<Guid, User>(dbContext: dbContext), IUserRepository
    {

        public override async Task DeleteEntityAsync(Guid userId, DeleteType type)
        {
            if (DeleteType.NoVisible == type)
                await dbContext.Users.Where(u => u.Id == userId)
                    .ExecuteUpdateAsync(q => q.SetProperty(u => u.IsDeleted,true));
            else
                 await base.DeleteEntityAsync(userId, type);
        }

        public async Task<UserDto> GetDtoAsync(Guid userId)
        {
            var user = await dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email
                }).AsNoTracking().FirstOrDefaultAsync();

            if (user != null)
                throw new Exception("User is not exist");

            return user;
        }

        public async Task<IEnumerable<UserDto>>? GetCollectionDtoAsync()
        {
            return await dbContext.Users
                .Select(u => new UserDto 
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email
                }).AsNoTracking().ToArrayAsync();
        }

        public async Task<UserShortDto> GetShortDtoAsync(Guid userId)
        {
            var user = await dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserShortDto
                {
                    Id = u.Id,
                    UserName = u.UserName
                }).AsNoTracking().FirstOrDefaultAsync();

            if (user != null)
                throw new Exception("User is not exist");

            return user;
        }

        public async Task<IEnumerable<UserShortDto>>? GetCollectionDtoShortAsync()
        {
            return await dbContext.Users
                .Select(u => new UserShortDto
                {
                    Id = u.Id,
                    UserName = u.UserName
                }).AsNoTracking().ToArrayAsync();
        }

        public async Task UpdateUserEntityAsync(UserDto userDto, UserModelType type)
        {
            await dbContext.Users.ExecuteUpdateAsync(set =>
            {
                if (userDto.UserName != null)
                    set.SetProperty(u => u.UserName, userDto.UserName);
                if (userDto.Email != null)
                    set.SetProperty(e => e.Email, userDto.Email);
            });
        }

        public async Task UpdateUserPasswordAsync(Guid userId, string hash)
        {
            await dbContext.Users.Where(u => u.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(h => h.PasswordHash, hash));
        }

        
    }
}
