namespace TokenVlidation.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(string sejourOrderId);
        //Task<bool> DeleteTokenAsync(string sejourOrderId);
        Task<bool> ValidateTokenAsync(string sejourOrderId, string token);
    }
}
