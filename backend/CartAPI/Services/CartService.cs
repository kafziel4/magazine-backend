using CartAPI.DTOs;
using CartAPI.Infrastructure;
using CartAPI.Model;

namespace CartAPI.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Cart> UpsertCart(CartRequestDto dto)
        {
            var products = await Task.WhenAll(GetProducts(dto));
            var cartItems = new List<CartItem>();

            foreach (var item in dto.Items)
            {
                var product = products.First(p => p?.Id == item.ProductId);
                cartItems.Add(
                    new CartItem(
                        product.Id,
                        product.Name,
                        product.Size,
                        product.Price,
                        product.Image,
                        item.Quantity));
            }

            var cart = new Cart(dto.CustomerId);
            cart.AddItems(cartItems);

            await _cartRepository.UpsertCart(cart);

            return cart;
        }

        private List<Task<Product>> GetProducts(CartRequestDto dto)
        {
            var queries = new List<Task<Product>>();

            foreach (var item in dto.Items)
            {
                var query = _productRepository.GetProduct(item.ProductId);
                queries.Add(query);
            }

            return queries;
        }
    }
}
