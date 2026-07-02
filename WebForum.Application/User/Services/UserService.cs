
using Microsoft.AspNetCore.Identity;
using WebForum.Application.User.Interfaces;
using WebForum.Core;
using WebForum.Core.Models;
using WebForum.Core.RequestModels;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;

namespace WebForum.Application.User.Services
{
    public class UserService(IUserRepository repository,
                             IPasswordHasher<string> passwordHasher,
                             IJwtProvider jwtProvider,
                             UserMapper mapper) : IUserService
    {
        public async Task<UserDto> AddAsync(RegistraitionUserDto dto)
        {
            bool userExist = await repository.UserExistByNameAsync(dto.UserName);

            if (userExist)
                throw new Exception("That username exsist");

            dto.Password = passwordHasher.HashPassword(dto.UserName, dto.Password);

            var entity = mapper.RegisterDtoToEntity(dto);

            await repository.CreateEntityAsync(entity);

            bool isCreated = await repository.CommitDbAsync();

            if (!isCreated)
                throw new Exception("Error creating user");

            return mapper.EntityToDto(entity);
        }

        public async Task<string> LoginUserAsync(AuthModel model)
        {
            var user = await repository.GetLoginDtoByNameAsync(model.UserName);

            if(user == null)
                throw new Exception("User is not exist");

            var result = passwordHasher.VerifyHashedPassword(model.UserName, user.PasswordHash, model.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Login failed");

            var userDto = await repository.GetDtoAsync(user.UserId);

            return jwtProvider.GenerateUser(userDto!);
        }

        public async Task<bool> DeleteAsync(Guid userId, DeleteType type)
        {
            return await repository.DeleteEntityAsync(userId, type);
        }

        public async Task<UserDto?> GetByIdAsync(Guid userId)
        {
            return await repository.GetDtoAsync(userId);
        }

        public async Task<bool> UpdateAsync(UserDto dto)
        {
            return await repository.UpdateUserEntityAsync(dto, UserModelType.Full);
        }
         
        public async Task<bool> UpdatePasswordAsync(Guid id, string newPawssword)
        {
            var user = await repository.GetShortDtoAsync(id);
            
            newPawssword = passwordHasher.HashPassword(user!.UserName, newPawssword);
            
            return await repository.UpdateUserPasswordAsync(id, newPawssword);
        }
    }
}
