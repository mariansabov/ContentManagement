using ContentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentManagement.Infrastructure.Configurations
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(a => a.Author)
                .WithMany(u => u.Announcements)
                .HasForeignKey(a => a.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
