using FluentValidation;

namespace Quotations.Models.FluentValidation
{
    public class GenericQuotationModelValidator<T> : AbstractValidator<T> where T : QuotationModelWithoutId
    {
        public GenericQuotationModelValidator() 
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Quotation content is required")
                .MaximumLength(300)
                .WithMessage("Quotation content is too long");
        }
    }
}
