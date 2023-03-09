using FluentValidation;

namespace Quotations.Models.FluentValidation
{
    public class InsertQuotationModelValidator : AbstractValidator<InsertQuotationModel>
    {
        public InsertQuotationModelValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Quotation content is required")
                .MaximumLength(300)
                .WithMessage("Quotation content is too long");
        }
    }
}
