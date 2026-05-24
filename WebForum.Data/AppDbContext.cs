using Microsoft.EntityFrameworkCore;
using WebForum.Data.Entities;
using WebForum.Infrastructure.Entities;

namespace WebForum.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public AppDbContext(DbContextOptions options) : base(options){}
    }
}
