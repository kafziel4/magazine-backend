using MongoDB.Driver;
using OrderAPI.DbContexts;
using OrderAPI.Model;

namespace OrderAPI.Infrastructure
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IAppDbContext _context;

        public OrdersRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders(string customerId) =>
            await _context.Orders
            .Find(o => o.CustomerId == customerId)
            .SortByDescending(o => o.Date)
            .ToListAsync();

        public async Task CreateOrder(Order order) =>
            await _context.Orders.InsertOneAsync(order);
    }
}
