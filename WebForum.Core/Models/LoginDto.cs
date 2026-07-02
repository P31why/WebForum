
namespace WebForum.Core.Models
{
    public class LoginDto
    {
        public required Guid UserId { get; set; }
        public required string PasswordHash { get; set; }
    }
}
