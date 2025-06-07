using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Authen.HashPass;
using PANAMA.Features.Authen.RefreshToken;

namespace PANAMA.Features.Authen.HashPass
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPut("HashPassCommand")]
        public async Task<IActionResult> RefreshToken([FromBody] HashPassCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
