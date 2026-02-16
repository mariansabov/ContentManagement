using ContentManagement.Domain.Entities;
using ContentManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContentManagement.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasIndex(u => u.Username).IsUnique();

            builder
                .Property(u => u.Role)
                .HasConversion(new EnumToStringConverter<UserRole>());
        }
    }
}
