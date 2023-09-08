using CatalogAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Brand = "Zara",
                Name = "Camisa Larga com Bolsos",
                Size = "M",
                Price = 70m,
                Image = "product-1.jpg",
                Feminine = false
            },
            new Product
            {
                Id = 2,
                Brand = "Zara",
                Name = "Casaco Reto com Lã",
                Size = "M",
                Price = 85m,
                Image = "product-2.jpg",
                Feminine = true
            },
            new Product
            {
                Id = 3,
                Brand = "Zara",
                Name = "Jaqueta com Efeito Camurça",
                Size = "M",
                Price = 60m,
                Image = "product-3.jpg",
                Feminine = false
            },
            new Product
            {
                Id = 4,
                Brand = "Zara",
                Name = "Sobretudo em Mescla de Lã",
                Size = "M",
                Price = 160m,
                Image = "product-4.jpg",
                Feminine = false
            },
            new Product
            {
                Id = 5,
                Brand = "Zara",
                Name = "Camisa Larga Acolchoada de Veludo Cotelê",
                Size = "M",
                Price = 110m,
                Image = "product-5.jpg",
                Feminine = false
            },
            new Product
            {
                Id = 6,
                Brand = "Zara",
                Name = "Casaco de Lã com Botões",
                Size = "M",
                Price = 170m,
                Image = "product-6.jpg",
                Feminine = true
            },
            new Product
            {
                Id = 7,
                Brand = "Zara",
                Name = "Casaco com Botões",
                Size = "M",
                Price = 75m,
                Image = "product-7.jpg",
                Feminine = true
            },
            new Product
            {
                Id = 8,
                Brand = "Zara",
                Name = "Colete Comprido com Cinto",
                Size = "M",
                Price = 88m,
                Image = "product-8.jpg",
                Feminine = true
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
