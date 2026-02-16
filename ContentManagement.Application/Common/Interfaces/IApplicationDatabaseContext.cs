using ContentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContentManagement.Application.Common.Interfaces
{
    public interface IApplicationDatabaseContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
