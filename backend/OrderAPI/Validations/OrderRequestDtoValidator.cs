using FluentValidation;
using OrderAPI.DTOs;

namespace OrderAPI.Validations
{
    public class OrderRequestDtoValidator : AbstractValidator<OrderRequestDto>
    {
        public OrderRequestDtoValidator()
        {
            RuleFor(o => o.CustomerId).NotEmpty();
        }
    }
}
