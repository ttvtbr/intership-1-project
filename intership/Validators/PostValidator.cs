
using FluentValidation;
using intership.DTOs;

namespace intership.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200);

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MaximumLength(1000);
        }
    }
}
