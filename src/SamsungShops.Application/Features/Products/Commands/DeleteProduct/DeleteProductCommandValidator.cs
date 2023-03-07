using FluentValidation;

namespace SamsungShops.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandHandlerQuery>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Product Id value not valid")
                .NotNull();
        }
    }
}
