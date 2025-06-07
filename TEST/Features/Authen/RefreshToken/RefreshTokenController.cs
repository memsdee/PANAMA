using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Authen.Login;

namespace PANAMA.Features.Authen.RefreshToken
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RefreshTokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
