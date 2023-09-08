using OrderAPI.Model;

namespace OrderAPI.Infrastructure
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetOrders(string customerId);
        Task CreateOrder(Order order);
    }
}
