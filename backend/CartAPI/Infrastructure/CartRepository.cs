using CartAPI.DTOs;
using CartAPI.Model;
using StackExchange.Redis;
using System.Text.Json;

namespace CartAPI.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _database;

        public CartRepository(ConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<CartResponseDto?> GetCart(string customerId)
        {
            string? jsonData = await _database.StringGetAsync(customerId);

            return jsonData is null ? null : JsonSerializer.Deserialize<CartResponseDto>(jsonData);
        }

        public async Task<bool> UpsertCart(Cart cart) =>
            await _database.StringSetAsync(
                cart.CustomerId, JsonSerializer.Serialize(cart));

        public async Task<bool> DeleteCart(string customerId) =>
            await _database.KeyDeleteAsync(customerId);
    }
}
