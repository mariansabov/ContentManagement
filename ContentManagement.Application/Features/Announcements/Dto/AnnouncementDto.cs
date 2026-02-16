using ContentManagement.Domain.Entities;

namespace ContentManagement.Application.Features.Announcements.Dto
{
    public record AnnouncementDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public string AuthorUsername { get; set; } = null!;
    }
}
