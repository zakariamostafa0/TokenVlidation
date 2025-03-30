using MediatR;
using TokenValidation.Core.Bases;
using TokenValidation.Core.Features.Order.Command.Models;
using TokenVlidation.Infrastructure.Interfaces;

namespace TokenValidation.Core.Features.Order.Command.Handlers
{
    public class ProcessRefundCommandHandler : ResponseHandler, IRequestHandler<ProcessRefundCommand, Response<string>>
    {
        private readonly ITokenService _tokenService;
        private readonly IOrderService _orderService;
        private readonly IBankService _bankService;
        private readonly IEmailService _emailService;

        public ProcessRefundCommandHandler(
            ITokenService tokenService,
            IOrderService orderService,
            IBankService bankService,
            IEmailService emailService)
        {
            _tokenService = tokenService;
            _orderService = orderService;
            _bankService = bankService;
            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(ProcessRefundCommand request, CancellationToken cancellationToken)
        {
            //Validate Token
            var tokenValidation = await _tokenService.ValidateTokenAsync(request.SejourOrderID, request.Token);
            if (!tokenValidation)
                return Unauthorized<string>("TokenNotValid");

            //Get Order Details
            var order = await _orderService.GetSejourOrderDetailsAsync(request.SejourOrderID);
            if (order == null)
                return NotFound<string>("Order not found.");

            //Validate Order Date
            bool isDateValid = order.OrderDate <= DateTime.UtcNow;
            if (!isDateValid)
                return Unauthorized<string>("Order date validation failed.");

            //Generate Bank Token
            string bankToken = await _bankService.GenerateBankTokenAsync(request.SejourOrderID);

            //Send Bank Refund Request
            bool refundSuccess = await _bankService.SendRefundRequestAsync(request.SejourOrderID, bankToken);
            if (!refundSuccess)
                return Unauthorized<string>("Bank refund request failed.");

            //Store Bank ID
            await _bankService.StoreBankIDAsync(request.SejourOrderID, bankToken);


            await _emailService.SendEmailAsync("user@example.com,user@example.com", "Refund Processed", "Your refund has been processed successfully.");

            return Success<string>("Success");
        }
    }
}
