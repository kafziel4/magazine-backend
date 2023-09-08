using CartAPI.Model;

namespace CartAPI.Infrastructure
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int productId);
    }
}
