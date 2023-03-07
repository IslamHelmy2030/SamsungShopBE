using FluentValidation;

namespace SamsungShops.Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommandValidator: AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product Name is required")
                .NotNull()
                .Length(3, 50);
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Product Description is required")
                .Length(3, 500);
            RuleFor(p => p.Summary)
                .NotEmpty().WithMessage("Product Summary is required")
                .Length(3, 500);
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Not valid price value");
            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("Not valid Category value");
        }
    }
}
