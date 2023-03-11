using FluentValidation;

namespace WebApi.Controllers.Categories.Models.FluentValidation
{
    public class InsertCategoryRequestValidator : AbstractValidator<InsertCategoryRequest>
    {
        public InsertCategoryRequestValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MinimumLength(3)
                .WithMessage("Category name is too short")
                .MaximumLength(30)
                .WithMessage("Category name is too long");
        }
    }
}
