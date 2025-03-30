using System.ComponentModel.DataAnnotations;

namespace TokenVlidation.Data.Entities
{
    public class SejourOrder
    {
        [Key]
        public string SejourOrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Token Token { get; set; }

        public int BankID { get; set; }
        public virtual Bank Bank { get; set; }
    }
}
