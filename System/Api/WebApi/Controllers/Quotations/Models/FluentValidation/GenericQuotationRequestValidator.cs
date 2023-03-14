using FluentValidation;

namespace WebApi.Controllers.Quotations.Models.FluentValidation
{
    public class GenericQuotationRequestValidator<T> : AbstractValidator<T> where T : QuotationMessageWithoutId
    {
        public GenericQuotationRequestValidator() 
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Quotation content is required")
                .MaximumLength(300)
                .WithMessage("Quotation content is too long");
        }
    }
}
