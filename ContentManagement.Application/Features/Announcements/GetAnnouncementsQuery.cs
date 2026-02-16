using AutoMapper;
using ContentManagement.Application.Features.Announcements.Dto;
using MediatR;
using AutoMapper.QueryableExtensions;
using ContentManagement.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContentManagement.Application.Features.Announcements
{
    public record GetAnnouncementsQuery : IRequest<List<AnnouncementDto>>;

    public class GetAnnouncementsHandler(IApplicationDatabaseContext context, IMapper mapper) : IRequestHandler<GetAnnouncementsQuery, List<AnnouncementDto>>
    {
        public async Task<List<AnnouncementDto>> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            return await context.Announcements
                .AsNoTracking()
                .ProjectTo<AnnouncementDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
