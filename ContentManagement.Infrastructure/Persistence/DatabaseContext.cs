using ContentManagement.Application.Common.Interfaces;
using ContentManagement.Domain.Entities;
using ContentManagement.Domain.Enums;
using ContentManagement.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ContentManagement.Infrastructure.Persistence
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options)
        : DbContext(options), IApplicationDatabaseContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurationAssembly = typeof(AnnouncementConfiguration).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(configurationAssembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            SeedBootstrapAdmin();
        }

        private void SeedBootstrapAdmin()
        {
            if (Users.Any(u => u.Username == "admin"))
            {
                return;
            }

            var adminUser = new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Email = "admin@random.com",
                Role = UserRole.Admin,
                CreatedAt = DateTime.UtcNow 
            };

            Users.Add(adminUser);

            SaveChanges();
        }
    }
}
