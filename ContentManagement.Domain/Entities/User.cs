using ContentManagement.Domain.Common;
using ContentManagement.Domain.Enums;

namespace ContentManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Author;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
        public ICollection<News> News { get; set; } = new List<News>();
    }
}
