using FluentValidation;

namespace Categories.Models.FluentValidation
{
    public class AddCategoryModelValidator : AbstractValidator<AddCategoryModel>
    {
        public AddCategoryModelValidator() 
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
