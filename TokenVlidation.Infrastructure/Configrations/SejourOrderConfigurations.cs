using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TokenVlidation.Data.Entities;

namespace TokenVlidation.Infrastructure.Configrations
{
    public class SejourOrderConfigurations
    {
        public void Configure(EntityTypeBuilder<SejourOrder> builder)
        {
            //order and token relationship
            builder.HasOne(s => s.Token)
                .WithOne(t => t.SejourOrder)
                .HasForeignKey<Token>(t => t.SejourOrderID)
                .OnDelete(DeleteBehavior.Cascade);

            //order and bank relationship
            builder.HasOne(s => s.Bank)
                .WithMany(b => b.SejourOrders)
                .HasForeignKey(s => s.BankID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
