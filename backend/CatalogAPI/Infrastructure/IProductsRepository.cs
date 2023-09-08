using CatalogAPI.Model;

namespace CatalogAPI.Infrastructure
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts(bool? feminine);
        Task<Product?> GetProduct(int id);

    }
}
