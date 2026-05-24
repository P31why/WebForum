
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using WebForum.Infrastructure;
using WebForum.Infrastructure.Entities;

namespace WebForum.Data.Entities
{
    public class User : IId<Guid>
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;
        
        public string PasswordHash { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
        
        public DateTime CreationDate { get; init; } = DateTime.Now;                     

        List<Topic> Topics { get; set; } = [];

        List<Post> Posts { get; set; } = [];

        List<Comment> Comments { get; set; } = [];


    }
}
