using System.Security.Cryptography;
using System.Text;
using TokenVlidation.Infrastructure.Interfaces;

namespace TokenVlidation.Infrastructure.Implementaions
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptToken(string sejourOrderID, int randomNumber)
        {
            string rawData = $"{sejourOrderID}{randomNumber}";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
