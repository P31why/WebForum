
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForum.Infrastructure.Entities;

namespace WebForum.Infrastructure.Configurations
{
    public class FollowedTopicConfiguration : IEntityTypeConfiguration<FollowedTopic>
    {
        public void Configure(EntityTypeBuilder<FollowedTopic> builder)
        {
            builder.HasIndex(ft => new { ft.UserId, ft.TopicId }).IsUnique();

            builder.HasOne(ft => ft.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ft => ft.Topic)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
