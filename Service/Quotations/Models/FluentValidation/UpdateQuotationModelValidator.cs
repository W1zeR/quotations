using FluentValidation;

namespace Quotations.Models.FluentValidation
{
    public class UpdateQuotationModelValidator : AbstractValidator<UpdateQuotationModel>
    {
        public UpdateQuotationModelValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Quotation content is required")
                .MaximumLength(300)
                .WithMessage("Quotation content is too long");
        }
    }
}
