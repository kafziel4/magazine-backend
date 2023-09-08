using CartAPI.DTOs;
using CartAPI.Model;

namespace CartAPI.Services
{
    public interface ICartService
    {
        Task<Cart> UpsertCart(CartRequestDto dto);
    }
}
