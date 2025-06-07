using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Project.GetAllProject;

namespace PANAMA.Features.Project.FindProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FindProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("FindProject")]
        public async Task<IActionResult> FindProject([FromQuery] FindProjectQuery request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
