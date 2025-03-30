using MediatR;
using TokenValidation.Core.Bases;

namespace TokenValidation.Core.Features.Order.Command.Models
{
    public class ProcessRefundCommand : IRequest<Response<string>>
    {
        public string SejourOrderID { get; set; }
        public string Token { get; set; }
    }
}
