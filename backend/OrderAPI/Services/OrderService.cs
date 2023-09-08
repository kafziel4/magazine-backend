using OrderAPI.DTOs;
using OrderAPI.Extensions;
using OrderAPI.Infrastructure;
using OrderAPI.Model;

namespace OrderAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICartRepository _cartRepository;

        public OrderService(IOrdersRepository ordersRepository, ICartRepository cartRepository)
        {
            _ordersRepository = ordersRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Order> CreateOrder(OrderRequestDto dto)
        {
            var cart = await _cartRepository.GetCart(dto.CustomerId);
            var orderItems = new List<OrderItem>();

            foreach (var cartItem in cart.Items)
            {
                var orderItem = cartItem.MapToOrderItem();
                orderItems.Add(orderItem);
            }

            var order = new Order(dto.CustomerId, cart.TotalPrice);
            order.AddItems(orderItems);

            await _ordersRepository.CreateOrder(order);

            return order;
        }
    }
}
