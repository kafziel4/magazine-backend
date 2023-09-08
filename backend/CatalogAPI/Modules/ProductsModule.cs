using CatalogAPI.Infrastructure;

namespace CatalogAPI.Modules
{
    public static class ProductsModule
    {
        public static IServiceCollection RegisterProductsModule(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }

        public static IEndpointRouteBuilder MapProductsEndpoins(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/products",
                async (IProductsRepository repository, bool? feminine) =>
            {
                var products = await repository.GetProducts(feminine);
                return Results.Ok(products);
            });

            endpoints.MapGet("/products/{id}",
                async (IProductsRepository repository, int id) =>
            {
                var product = await repository.GetProduct(id);
                return product is null ? Results.NotFound() : Results.Ok(product);
            });

            return endpoints;
        }
    }
}
