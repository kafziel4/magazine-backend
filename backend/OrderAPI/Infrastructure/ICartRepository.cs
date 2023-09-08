using OrderAPI.Model;

namespace OrderAPI.Infrastructure
{
    public interface ICartRepository
    {
        Task<Cart> GetCart(string customerId);
    }
}
