using FluentValidation;

namespace WebApi.Controllers.Comments.Models.FluentValidation
{
    public class GenericCommentRequestValidator<T> : AbstractValidator<T> where T : CommentMessageWithoutId
    {
        public GenericCommentRequestValidator() 
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment content is required")
                .MaximumLength(500)
                .WithMessage("Comment content is too long");
        }
    }
}
