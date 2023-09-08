using FluentValidation;
using OrderAPI.DTOs;
using OrderAPI.Exceptions;
using OrderAPI.Infrastructure;
using OrderAPI.Services;
using OrderAPI.Validations;

namespace OrderAPI.Modules
{
    public static class OrdersModule
    {
        public static IServiceCollection RegisterOrdersModule(this IServiceCollection services)
        {
            services.AddScoped<IValidator<OrderRequestDto>, OrderRequestDtoValidator>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddSingleton<IOrdersRepository, OrdersRepository>();

            return services;
        }

        public static IEndpointRouteBuilder MapOrdersEndpoins(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/orders/{customerId}",
                async (IOrdersRepository repository, string customerId) =>
            {
                var orders = await repository.GetOrders(customerId);
                return Results.Ok(orders);
            });

            endpoints.MapPost("/orders",
                async (IValidator<OrderRequestDto> validator, IOrderService service, OrderRequestDto dto) =>
            {
                try
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                        return Results.ValidationProblem(validationResult.ToDictionary());

                    var order = await service.CreateOrder(dto);
                    return Results.Ok(order);
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

            return endpoints;
        }
    }
}
