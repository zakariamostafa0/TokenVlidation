using System.ComponentModel.DataAnnotations;

namespace TokenVlidation.Data.Entities
{
    public class Token
    {
        [Key]
        public int TokenID { get; set; }

        public string EncryptedToken { get; set; }
        public DateTime CreatedAt { get; set; }

        public string SejourOrderID { get; set; }
        public virtual SejourOrder SejourOrder { get; set; }
    }
}
