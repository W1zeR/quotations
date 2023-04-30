using FluentValidation;

namespace WebApi.Controllers.Users.Models.FluentValidation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MaximumLength(50)
                .WithMessage("Password is long");
        }
    }
}
