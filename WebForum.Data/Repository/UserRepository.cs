using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Core.Models;
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
            int rows = 0;
            bool isComplete = false;

            if (DeleteType.NoVisible == type)
            {
                rows = await _dbSet.Where(u => u.Id == userId)
                    .ExecuteUpdateAsync(q => q.SetProperty(u => u.IsDeleted, true));

                isComplete = rows > 0 ? true : false;
            }
            else
                 await base.DeleteEntityAsync(userId, type);

            return isComplete;
        }

        public async Task<UserDto?> GetDtoAsync(Guid userId)
        {
            var user = await _dbSet
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .Select(u => mapper.EntityToDto(u))
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IReadOnlyCollection<UserDto>?> GetCollectionDtoAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Select(u => mapper.EntityToDto(u))
                .ToArrayAsync();
        }

        public async Task<UserShortDto?> GetShortDtoAsync(Guid userId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.Id == userId)
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
                .Select(u => new UserShortDto
                {
                    Id = u.Id,
                    UserName = u.UserName
                })
                .ToArrayAsync();
        }

        public async Task<bool> UpdateUserEntityAsync(UserDto userDto, UserModelType type)
        {
            int rows = 0;

            rows = await _dbSet
                .Where(i => i.Id == userDto.Id)
                .ExecuteUpdateAsync(set =>
                {
                    set.SetProperty(u => u.UserName, userDto.UserName);
                    set.SetProperty(e => e.Email, userDto.Email);
                });

            return rows > 0 ? true : false;
        }

        public async Task<bool> UpdateUserPasswordAsync(Guid userId, string hash)
        {
            int rows = 0;

            rows = await _dbSet.Where(u => u.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(h => h.PasswordHash, hash));

            return rows > 0 ? true : false;
        }

        public async Task<UserDto> AddNewUser(RegistraitionUserDto dto)
        {
            await _dbSet.AddAsync(new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                IsDeleted = false
            });

        }
    }
}
