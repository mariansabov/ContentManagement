using ContentManagement.Domain.Common;
using ContentManagement.Domain.Enums;

namespace ContentManagement.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public NewsStatus Status { get; set; } = NewsStatus.Draft;

        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;
    }
}
