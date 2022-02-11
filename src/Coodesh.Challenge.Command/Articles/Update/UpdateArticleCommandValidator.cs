using FluentValidation;

namespace Coodesh.Challenge.Command.Articles.Update
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
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