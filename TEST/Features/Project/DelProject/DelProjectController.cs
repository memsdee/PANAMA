using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Project.EditProject;

namespace PANAMA.Features.Project.DelProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DelProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("DelProject")]
        public async Task<IActionResult> DelProject([FromBody] DelProjectCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
