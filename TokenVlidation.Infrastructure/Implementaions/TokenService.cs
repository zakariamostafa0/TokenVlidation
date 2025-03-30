using Microsoft.EntityFrameworkCore;
using TokenVlidation.Data.Entities;
using TokenVlidation.Infrastructure.Context;
using TokenVlidation.Infrastructure.Interfaces;

namespace TokenVlidation.Infrastructure.Implementaions
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEncryptionService _encryptionService;

        public TokenService(ApplicationDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<string> GenerateTokenAsync(string sejourOrderId)
        {
            try
            {
                int randomNumber = new Random().Next(1000, 9999);
                var token = _encryptionService.EncryptToken(sejourOrderId, randomNumber);

                var tokenEntity = new Token
                {
                    SejourOrderID = sejourOrderId,
                    EncryptedToken = token,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Tokens.Add(tokenEntity);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ($"Error generating token: {ex.Message}");
            }
        }


        public async Task<bool> ValidateTokenAsync(string sejourOrderId, string token)
        {
            var tokenEntity = await _context.Tokens.FirstOrDefaultAsync(t => t.SejourOrderID == sejourOrderId);
            if (tokenEntity == null)
            {
                return false;
            }
            if (tokenEntity.EncryptedToken != token)
            {
                return false;
            }
            return true;
        }
    }
}
