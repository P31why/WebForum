
namespace WebForum.Core.Models
{
    public class UserDto : UserShortDto
    {
        public string? Email { get; set; }
    }

    public class UserShortDto
    {
        public required Guid Id { get; set; }

        public required string UserName { get; set; }
    }
}
