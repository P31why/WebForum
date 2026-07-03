
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebForum.Data;

namespace WebForum.Infrastructure
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            string configPath = Path.Combine(Directory.GetCurrentDirectory(),"..", "WebForum");

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            
            return new AppDbContext(builder.Options);
        }
    }
}
