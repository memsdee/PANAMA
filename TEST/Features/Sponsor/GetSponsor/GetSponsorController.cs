using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Project.GetAllProject;

namespace PANAMA.Features.Sponsor.GetSponsor
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSponsorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetSponsorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSponsor")]
        public async Task<IActionResult> GetProjectCategory([FromQuery] GetSponsorQuery request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
