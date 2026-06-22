
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Application.User.Services
{
    public class UserService(IUserRepository repository, UserMapper mapper) : IUserService
    {
        public async Task<UserDto> AddAsync(UserDto dto)
        {
            var entity = await repository.CreateEntityAsync(mapper.DtoToEntity(dto));

            if (entity == null)
                throw new Exception("User creating error");

            return mapper.EntityToDto(entity);
        }

        public async Task<bool> DeleteAsync(Guid userId, DeleteType type)
        {
            return await repository.DeleteEntityAsync(userId, type);
        }

        public async Task<UserDto> GetByIdAsync(Guid userId)
        {
            return await repository.GetDtoAsync(userId);
        }

        public async Task<bool> UpdateAsync(UserDto dto)
        {
            return await repository.UpdateUserEntityAsync(dto, UserModelType.Full);
        }

        public async Task<bool> UpdatePasswordAsync(Guid id, string hash)
        {
            return await repository.UpdateUserPasswordAsync(id, hash);
        }
    }
}
