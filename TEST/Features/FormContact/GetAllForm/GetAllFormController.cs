using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.FormContact.SendForm;

namespace PANAMA.Features.FormContact.GetAllForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllFormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllForm")]
        public async Task<IActionResult> SendForm([FromQuery]GetAllFormQuery request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
