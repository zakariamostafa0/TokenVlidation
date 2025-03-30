using MediatR;
using TokenValidation.Core.Bases;
using TokenValidation.Core.Features.Tokens.Command.Models;
using TokenVlidation.Infrastructure.Interfaces;

namespace TokenValidation.Core.Features.Tokens.Command.Handlers
{
    public class TokenCommandHandler : ResponseHandler,
                        IRequestHandler<GenerateTokenCommand, Response<string>>
    {
        private readonly ITokenService _tokenService;

        public TokenCommandHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<Response<string>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _tokenService.GenerateTokenAsync(request.SejourOrderID);
            return Success<string>(result);
        }
    }
}
