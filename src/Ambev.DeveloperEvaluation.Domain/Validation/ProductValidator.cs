using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Title is required.");
            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("Description is required.");
            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(product => product.Category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");
            RuleFor(product => product.Image)
                .NotEmpty().WithMessage("Image URL is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Image URL must be a valid URL.");
            RuleFor(product => product.Rating).SetValidator(new RatingValidator());
            RuleFor(product => product.Rating)
                .NotEmpty().WithMessage("Rating is required.");
            
        }
    }
}
