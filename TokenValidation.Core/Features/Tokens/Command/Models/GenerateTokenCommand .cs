using MediatR;
using TokenValidation.Core.Bases;

namespace TokenValidation.Core.Features.Tokens.Command.Models
{
    public class GenerateTokenCommand : IRequest<Response<string>>
    {
        public string SejourOrderID { get; set; }
    }
}
