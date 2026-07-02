
using System.ComponentModel.DataAnnotations;

namespace WebForum.Core.RequestModels
{
    public class RegistraitionUserDto
    {
        public required string UserName { get; set; }

        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }

    public class AuthModel
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }
    }
}
