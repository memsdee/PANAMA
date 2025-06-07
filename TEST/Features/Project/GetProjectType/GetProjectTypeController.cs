using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Project.GetAllProject;

namespace PANAMA.Features.Project.GetProjectType
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProjectTypeController : ControllerBase
    {
        
            private readonly IMediator _mediator;

            public GetProjectTypeController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet("GetProjectType")]
            public async Task<IActionResult> GetProjectType([FromQuery] GetProjectTypeQuery request)
            {
                var x = await _mediator.Send(request);
                return Ok(x);
            }
          }
}

