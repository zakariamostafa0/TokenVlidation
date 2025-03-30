namespace TokenVlidation.Infrastructure.Interfaces
{
    public interface IEncryptionService
    {
        public string EncryptToken(string sejourOrderID, int randomNumber);
    }
}
