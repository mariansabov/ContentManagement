using ContentManagement.Domain.Common;

namespace ContentManagement.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public int HoursToLive { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;
    }
}
