using TokenVlidation.Data.Entities;
using TokenVlidation.Infrastructure.Interfaces;

namespace TokenVlidation.Infrastructure.Implementaions
{
    public class OrderService : IOrderService
    {
        public Task<SejourOrder> GetSejourOrderDetailsAsync(string sejourOrderID)
        {
            throw new NotImplementedException();
        }
    }
}
