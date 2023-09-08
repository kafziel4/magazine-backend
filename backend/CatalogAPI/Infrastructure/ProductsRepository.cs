using CatalogAPI.DbContexts;
using CatalogAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Infrastructure
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts(bool? feminine) =>
            feminine is null ?
                await _context.Products.ToListAsync() :
                await _context.Products.Where(p => p.Feminine == feminine).ToListAsync();

        public async Task<Product?> GetProduct(int id) =>
            await _context.Products.FindAsync(id);
    }
}
