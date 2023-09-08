using CartAPI.DTOs;
using CartAPI.Exceptions;
using CartAPI.Infrastructure;
using CartAPI.Services;
using CartAPI.Validators;
using FluentValidation;

namespace CartAPI.Modules
{
    public static class CartModule
    {
        public static IServiceCollection RegisterCartModule(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CartRequestDto>, CartRequestDtoValidator>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IEndpointRouteBuilder MapCartEndpoins(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/cart/{customerId}",
                async (ICartRepository repository, string customerId) =>
            {
                var cart = await repository.GetCart(customerId);
                return cart is null ? Results.NotFound() : Results.Ok(cart);
            });

            endpoints.MapPost("/cart",
                async (IValidator<CartRequestDto> validator, ICartService service, CartRequestDto dto) =>
            {
                try
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                        return Results.ValidationProblem(validationResult.ToDictionary());

                    var cart = await service.UpsertCart(dto);
                    return Results.Ok(cart);
                }
                catch (NotFoundException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
                catch (InfrastructureException ex)
                {
                    return Results.Problem(ex.Message, statusCode: 500);
                }
            });

            endpoints.MapDelete("/cart/{customerId}",
                async (ICartRepository repository, string customerId) =>
            {
                var deleted = await repository.DeleteCart(customerId);
                return deleted ? Results.NoContent() : Results.NotFound();
            });

            return endpoints;
        }
    }
}
