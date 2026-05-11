using Microsoft.EntityFrameworkCore;
using WebForum.Data.Entities;

namespace WebForum.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options){}
    }
}
