namespace TokenVlidation.Infrastructure.Interfaces
{
    public interface IBankService
    {
        public Task<string> GenerateBankTokenAsync(string sejourOrderID);
        public Task<bool> SendRefundRequestAsync(string sejourOrderID, string bankToken);
        public Task StoreBankIDAsync(string sejourOrderID, string bankToken);
    }
}
