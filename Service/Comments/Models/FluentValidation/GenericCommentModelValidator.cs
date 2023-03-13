using FluentValidation;

namespace Comments.Models.FluentValidation
{
    public class GenericCommentModelValidator<T> : AbstractValidator<T> where T : CommentModelWithoutId
    {
        public GenericCommentModelValidator() 
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment content is required")
                .MaximumLength(500)
                .WithMessage("Comment content is too long");
        }
    }
}
