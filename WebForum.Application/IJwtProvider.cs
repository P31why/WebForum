
using WebForum.Core.Models;

namespace WebForum.Application
{
    public interface IJwtProvider
    {
        public string GenerateUser(UserDto dto);
    }
}
