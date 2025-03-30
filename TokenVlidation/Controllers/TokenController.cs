using MediatR;
using Microsoft.AspNetCore.Mvc;
using TokenValidation.Core.Features.Tokens.Command.Models;

namespace TokenValidation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.SejourOrderID))
                return BadRequest("SejourOrderID is required");

            var token = await _mediator.Send(command);
            return Ok(new { Token = token });
        }
    }
}
