using CartAPI.Exceptions;
using CartAPI.Model;
using System.Net;
using System.Text.Json;

namespace CartAPI.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private const string ClientName = "Catalog";
        private const string ProductsUrl = "/products";
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Product> GetProduct(int productId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(ClientName);
                var response = await client.GetAsync($"{ProductsUrl}/{productId}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStreamAsync();
                var product = await JsonSerializer.DeserializeAsync<Product>(
                    content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return product ??
                    throw new InfrastructureException($"Error while deserializing product with id {productId}.");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException($"Product with id {productId} was not found.", ex);
            }
        }
    }
}
