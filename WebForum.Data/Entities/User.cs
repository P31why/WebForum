
using WebForum.Infrastructure;

namespace WebForum.Data.Entities
{
    public class User : IId<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;
        
        public string PasswordHash { get; set; } = string.Empty;

        public required bool IsDeleted { get; set; }
        
        public DateTime CreationDate { get; init; } = DateTime.Now;
    }
}
