using Blog.API.Model;
using FluentValidation;

namespace Blog.API.Validations;

public class ArticleValidator : AbstractValidator<Article>
{
    public ArticleValidator()
    {

        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required")
            .Must(x => x > 0).WithMessage("Id must be greater than 0");

        RuleFor(x => x.Title).NotEmpty()
        .Length(1, 100)
        .WithMessage("Title is required");

        RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required")
            .Length(100, 1000).WithMessage("Content should be at least 100 to 1000 characters long");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author is required")
            .Length(1, 50).WithMessage("Author should be at least 1 to 50 characters long")
            .Matches(@"^[a-zA-Z\s]+$").WithMessage("Author should only contain letters and spaces");

        RuleFor(x => x.CreatedAt)
            .NotEmpty().WithMessage("CreatedAt is required")
            .Must(x => x > DateTime.MinValue).WithMessage("CreatedAt should be a valid date");

        RuleFor(x => x.UpdatedAt)
            .NotEmpty().WithMessage("UpdatedAt is required")
            .Must(x => x > DateTime.MinValue).WithMessage("UpdatedAt should be a valid date");

        //boolean properties in C# is either true or false so we dont need to validate them
    }
}
