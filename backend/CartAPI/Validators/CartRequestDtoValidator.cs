using CartAPI.DTOs;
using FluentValidation;

namespace CartAPI.Validators
{
    public class CartRequestDtoValidator : AbstractValidator<CartRequestDto>
    {
        public CartRequestDtoValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleForEach(c => c.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.Quantity).GreaterThan(0);
            });
        }
    }
}
