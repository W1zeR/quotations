using FluentValidation;

namespace Categories.Models.FluentValidation
{
    public class InsertCategoryModelValidator : AbstractValidator<InsertCategoryModel>
    {
        public InsertCategoryModelValidator() 
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
