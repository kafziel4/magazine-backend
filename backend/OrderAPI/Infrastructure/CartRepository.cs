using OrderAPI.Exceptions;
using OrderAPI.Model;
using System.Net;
using System.Text.Json;

namespace OrderAPI.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private const string ClientName = "Cart";
        private const string CartUrl = "/cart";
        private readonly IHttpClientFactory _httpClientFactory;

        public CartRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Cart> GetCart(string customerId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(ClientName);
                var response = await client.GetAsync($"{CartUrl}/{customerId}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStreamAsync();
                var cart = await JsonSerializer.DeserializeAsync<Cart>(
                    content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return cart ??
                    throw new InfrastructureException($"Error while deserializing cart for customer {customerId}.");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException($"Cart for customer {customerId} was not found.", ex);
            }
        }
    }
}
