using CartAPI.DTOs;
using CartAPI.Model;

namespace CartAPI.Infrastructure
{
    public interface ICartRepository
    {
        Task<CartResponseDto?> GetCart(string customerId);
        Task<bool> UpsertCart(Cart cart);
        Task<bool> DeleteCart(string customerId);
    }
}
