using OrderAPI.DTOs;
using OrderAPI.Model;

namespace OrderAPI.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderRequestDto dto);
    }
}
