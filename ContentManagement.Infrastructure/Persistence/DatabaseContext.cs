
using ContentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContentManagement.Infrastructure.Persistence
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<News> News { get; set; }   

        public DbSet<Announcement> Announcements { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure relationships and constraints if needed
            modelBuilder.Entity<News>()
                .HasOne(n => n.Author)
                .WithMany()
                .HasForeignKey(n => n.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Announcement>()
                .HasOne(a => a.Author)
                .WithMany()
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
