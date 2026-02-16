using ContentManagement.Application.Common.Interfaces;
using ContentManagement.Domain.Entities;
using ContentManagement.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ContentManagement.Infrastructure.Persistence
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options), IApplicationDatabaseContext
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
    }
}
