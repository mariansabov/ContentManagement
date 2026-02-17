using ContentManagement.Application.Features.Announcements;
using ContentManagement.Application.Features.Announcements.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagement.ContentApi.Controllers
{
    [ApiController]
    [Route("contentApi/[controller]")]
    public class AnnouncementsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AnnouncementDto>>> GetAll()
        {
            var announcements = await mediator.Send(new GetAnnouncementsQuery());
            return Ok(announcements);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAnnouncementCommand command)
        {
            var announcementId = await mediator.Send(command);
            return Ok(announcementId);
        }
    }
}
