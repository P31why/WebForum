
namespace WebForum.Core.Models
{
    public class UserDto : UserShortDto
    {
        public string Email { get; set; }
    }

    public class UserShortDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
