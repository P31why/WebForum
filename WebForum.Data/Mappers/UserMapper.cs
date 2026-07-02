
using Riok.Mapperly.Abstractions;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
using WebForum.Data.Entities;

namespace WebForum.Infrastructure.Mappers
{
    [Mapper]
    public partial class UserMapper
    {
        [UserMapping]
        public User DtoToEntity(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Email = dto.Email,
                UserName = dto.UserName,
                IsDeleted = dto.IsDeleted,
            };
        }

        [UserMapping]
        public UserDto EntityToDto(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                IsDeleted = entity.IsDeleted,
            };
        }

        [UserMapping]
        public UserShortDto EntityToShortDto(User entity)
        {
            return new UserShortDto
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                UserName = entity.UserName
            };
        }

        [UserMapping]
        public User RegisterDtoToEntity(RegistraitionUserDto dto)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                Email = dto.Email,
                IsDeleted = false,
                PasswordHash = dto.Password,
                CreationDate = DateTime.UtcNow
            };
        }
    }
}
