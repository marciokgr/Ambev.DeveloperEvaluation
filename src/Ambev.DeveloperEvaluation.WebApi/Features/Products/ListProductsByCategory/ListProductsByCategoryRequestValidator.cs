using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

public class ListProductsByCategoryRequestValidator : AbstractValidator<ListProductsByCategoryRequest>
{
    public ListProductsByCategoryRequestValidator()
    {
        RuleFor(product => product.Category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");
    }
}