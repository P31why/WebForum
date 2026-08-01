using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
using WebForum.Data;
using WebForum.Data.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Infrastructure.Repository
{
    public class UserRepository(AppDbContext dbContext, UserMapper mapper) : BaseRepository<Guid, User>(dbContext: dbContext), IUserRepository
    {

        public override async Task<bool> DeleteEntityAsync(Guid userId, DeleteType type)
        {
            if (DeleteType.NoVisible == type)
            {
                return await _dbSet.Where(u => u.Id == userId && u.IsDeleted == false)
                    .ExecuteUpdateAsync(q => q.SetProperty(u => u.IsDeleted, true)) > 0;
            }
            
            return await base.DeleteEntityAsync(userId, type);
        }

        public async Task<UserDto?> GetDtoAsync(Guid userId)
        {
            var user = await _dbSet
                .AsNoTracking()
                .Where(u => u.Id == userId && u.IsDeleted == false)
                .Select(u => mapper.EntityToDto(u))
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IReadOnlyCollection<UserDto>?> GetCollectionDtoAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.IsDeleted == false)
                .Select(u => mapper.EntityToDto(u))
                .ToArrayAsync();
        }

        public async Task<UserShortDto?> GetShortDtoAsync(Guid userId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.Id == userId && u.IsDeleted == false)
                .Select(u => new UserShortDto
                {
                    Id = u.Id,
                    UserName = u.UserName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<UserShortDto>?> GetCollectionShortDtoAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.IsDeleted == false)
                .Select(u => new UserShortDto
                {
                    Id = u.Id,
                    UserName = u.UserName
                })
                .ToArrayAsync();
        }

        public async Task<bool> UpdateUserEntityAsync(UpdateUserRequestModel userDto, UserModelType type)
        {
            int rows = 0;

            rows = await _dbSet
                .Where(u => u.Id == userDto.Id && u.IsDeleted == false)
                .ExecuteUpdateAsync(set =>
                {
                    //set.SetProperty(u => u.UserName, userDto.UserName ?? null);
                    set.SetProperty(e => e.Email, userDto.Email ?? null);
                });

            return rows > 0;
        }

        public async Task<bool> UpdateUserPasswordAsync(Guid userId, string hash)
        {
            int rows = 0;

            rows = await _dbSet.Where(u => u.Id == userId && u.IsDeleted == false)
                .ExecuteUpdateAsync(u => u.SetProperty(h => h.PasswordHash, hash));

            return rows > 0;
        }


        //TODO: объеденить в один метод UserExistByAsync
        public async Task<bool> UserExistByNameAsync(string name)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.UserName == name && u.IsDeleted == false)
                .FirstOrDefaultAsync() != null;
        }

        public async Task<bool> UserExistByEmailAsync(string email)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.Email == email && u.IsDeleted == false)
                .FirstOrDefaultAsync() != null;
        }

        public async Task<LoginDto?> GetLoginDtoByNameAsync(string name)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.UserName == name && u.IsDeleted == false)
                .Select(u => new LoginDto 
                {
                    UserId = u.Id,
                    PasswordHash = u.PasswordHash,
                })
                .FirstOrDefaultAsync();
        }
    }
}
