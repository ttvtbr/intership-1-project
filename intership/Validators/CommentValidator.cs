
using FluentValidation;
using intership.DTOs;

namespace intership.Validators
{
    public class CommentValidator : AbstractValidator<CommentDto>
    {
        public CommentValidator()
        {
            RuleFor(x => x.PostId).GreaterThan(0);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
            RuleFor(x => x.UserName).MaximumLength(80);
        }
    }
}
