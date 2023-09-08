using OrderAPI.Model;

namespace OrderAPI.Extensions
{
    public static class CartItemExtensions
    {
        public static OrderItem MapToOrderItem(this CartItem item) =>
            new(item.ProductId, item.Name, item.Size, item.Price, item.Image, item.Quantity);
    }
}
