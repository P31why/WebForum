
using System.ComponentModel.DataAnnotations;
using WebForum.Infrastructure;
using WebForum.Infrastructure.Entities;

namespace WebForum.Data.Entities
{
    public class User : IId<Guid>
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;
        
        public string PasswordHash { get; set; } = string.Empty;
        
        public DateTime CreationDate { get; init; } = DateTime.Now;

        List<Topic> Topics { get; set; } = [];

        List<Post> Posts { get; set; } = [];

        List<Comment> Comments { get; set; } = [];


    }
}
