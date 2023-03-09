using FluentValidation;

namespace Comments.Models.FluentValidation
{
    public class UpdateCommentModelValidator : AbstractValidator<UpdateCommentModel>
    {
        public UpdateCommentModelValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment content is required")
                .MaximumLength(500)
                .WithMessage("Comment content is too long");
        }
    }
}
