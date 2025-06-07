using Microsoft.AspNetCore.Http;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelSponsorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DelSponsorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("DelSponsor")]
        public async Task<IActionResult> AddProject([FromForm] DelSponsorCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
