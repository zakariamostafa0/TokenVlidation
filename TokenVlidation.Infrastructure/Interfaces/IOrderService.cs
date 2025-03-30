using TokenVlidation.Data.Entities;

namespace TokenVlidation.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        public Task<SejourOrder> GetSejourOrderDetailsAsync(string sejourOrderID);

    }
}
