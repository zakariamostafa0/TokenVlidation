using System.ComponentModel.DataAnnotations;

namespace TokenVlidation.Data.Entities
{
    public class Bank
    {
        [Key]
        public int BankID { get; set; }

        public string TermKey { get; set; }
        public string MerchantID { get; set; }

        public virtual ICollection<SejourOrder> SejourOrders { get; set; }
    }
}
