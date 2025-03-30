using MediatR;
using Microsoft.AspNetCore.Mvc;
using TokenValidation.Core.Features.Order.Command.Models;

namespace TokenValidation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("process-refund")]
        public async Task<IActionResult> ProcessRefund([FromBody] ProcessRefundCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Succeeded)
                return Unauthorized(response.Message);

            return Ok(response);
        }
    }
}
