
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasOne(t => t.Creator)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
