using TokenVlidation.Infrastructure.Interfaces;

namespace TokenVlidation.Infrastructure.Implementaions
{
    public class BankService : IBankService
    {
        public Task<string> GenerateBankTokenAsync(string sejourOrderID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendRefundRequestAsync(string sejourOrderID, string bankToken)
        {
            throw new NotImplementedException();
        }

        public Task StoreBankIDAsync(string sejourOrderID, string bankToken)
        {
            throw new NotImplementedException();
        }
    }
}
