using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Authen.RefreshToken;

namespace PANAMA.Features.FormContact.SendForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendFormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SendFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SendForm")]
        public async Task<IActionResult> SendForm([FromBody] SendFormCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
