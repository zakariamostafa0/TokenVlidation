namespace TokenVlidation.Data.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public string SejourOrderID { get; set; }
        public string EncryptedToken { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
