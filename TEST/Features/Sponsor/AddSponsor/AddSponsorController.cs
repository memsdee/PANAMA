using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Project.AddProject;
using PANAMA.Features.Project.DelProject;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddSponsorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddSponsorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddSponsor")]
        public async Task<IActionResult> DelProject([FromForm] AddSponsorCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
