using FluentValidation;

namespace Coodesh.Challenge.Command.Commands.Articles.Create
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(field => field.Title)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(field => field.Url)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(field => field.ImageUrl)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(field => field.NewsSite)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(field => field.Summary)
                .MaximumLength(600);

            RuleFor(field => field.PublishedAt)
                .NotEmpty();
        }
    }
}