using Blog.API.Model;
using FluentValidation;

namespace Blog.API.Validations
{
    //write fluent validation for the class Article1
    public class TestValidator : AbstractValidator<TestArticle>
    {
        public TestValidator()
        {
            //write fluent validation for Id property with required and integer type
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required")
                .Must(x => x > 0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required");
            //write fluent validation for CreatedAt property with required and DateTime type

            RuleFor(x => x.CreatedAt).NotEmpty().WithMessage("CreatedAt is required");
            RuleFor(x => x.UpdatedAt).NotEmpty().WithMessage("UpdatedAt is required");
            RuleFor(x => x.IsPublished).NotEmpty().WithMessage("IsPublished is required");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("IsDeleted is required");
            //RuleFor(x => x.Tags).NotEmpty().WithMessage("Tags is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        }
    }
}
