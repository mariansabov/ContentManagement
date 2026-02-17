using ContentManagement.Application.Common.Interfaces;
using ContentManagement.Domain.Entities;
using MediatR;

namespace ContentManagement.Application.Features.Announcements
{
    public record CreateAnnouncementCommand(
        string Title,
        string Content,
        int HoursToLive,
        Guid AuthorId) : IRequest<Guid>;

    public class CreateAnnouncementHandler(IApplicationDatabaseContext context) : IRequestHandler<CreateAnnouncementCommand, Guid>
    {
        public async Task<Guid> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;

            var announcementEntity = new Announcement
            {
                Title = request.Title,
                Content = request.Content,
                HoursToLive = request.HoursToLive,
                CreatedAt = now,
                ExpiresAt = now.AddHours(request.HoursToLive),
                AuthorId = request.AuthorId
            };

            await context.Announcements.AddAsync(announcementEntity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return announcementEntity.Id;
        }
    }
}
