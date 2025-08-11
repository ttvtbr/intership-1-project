
using FluentValidation;
using intership.DTOs;

namespace intership.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.AuthorName).MaximumLength(80);
        }
    }
}
