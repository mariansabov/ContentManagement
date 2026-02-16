using ContentManagement.Domain.Entities;
using ContentManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContentManagement.Infrastructure.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(n => n.Status)
                .HasConversion(new EnumToStringConverter<NewsStatus>());

            builder.HasOne(n => n.Author)   
                .WithMany(u => u.News)
                .HasForeignKey(n => n.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
