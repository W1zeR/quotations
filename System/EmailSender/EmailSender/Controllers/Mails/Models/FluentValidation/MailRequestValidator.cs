using FluentValidation;

namespace EmailSender.Controllers.Mails.Models.FluentValidation
{
    public class MailRequestValidator : AbstractValidator<MailRequest>
    {
        public MailRequestValidator()
        {
            RuleForEach(x => x.To)
                .EmailAddress()
                .WithMessage("Emails are required");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .WithMessage("Subject is required");

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage("Body is required");
        }
    }
}
