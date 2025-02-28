using Blog.API.Model;
using Blog.API.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace Blog.API.Tests.Validations
{
    public class ArticleValidatorTests
    {
        private readonly ArticleValidator _validator;

        public ArticleValidatorTests()
        {
            _validator = new ArticleValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            var model = new Article { Id = 0 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Id_Is_Valid()
        {
            var model = new Article { Id = 1 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        //write unit tests for Valid Id using theory and inline data
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void IdIsValid(int id)
        {
            var model = new Article { Id = id };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Should_Have_Error_When_Title_Is_Empty()
        {
            var model = new Article { Title = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Title_Is_Valid()
        {
            var model = new Article { Title = "Valid Title" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Should_Have_Error_When_Content_Is_Empty()
        {
            var model = new Article { Content = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Content);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Content_Is_Valid()
        {
            var model = new Article { Content = "Valid Content" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Content);
        }

        [Fact]
        public void Should_Have_Error_When_Author_Is_Empty()
        {
            var model = new Article { Author = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Author);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Author_Is_Valid()
        {
            var model = new Article { Author = "Valid Author" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Author);
        }

        [Fact]
        public void Should_Have_Error_When_CreatedAt_Is_Empty()
        {
            var model = new Article { CreatedAt = default };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CreatedAt);
        }

        [Fact]
        public void Should_Not_Have_Error_When_CreatedAt_Is_Valid()
        {
            var model = new Article { CreatedAt = DateTime.Now };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.CreatedAt);
        }

        [Fact]
        public void Should_Have_Error_When_UpdatedAt_Is_Empty()
        {
            var model = new Article { UpdatedAt = default };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.UpdatedAt);
        }

        [Fact]
        public void Should_Not_Have_Error_When_UpdatedAt_Is_Valid()
        {
            var model = new Article { UpdatedAt = DateTime.Now };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.UpdatedAt);
        }

        [Fact]
        public void Should_Have_Error_When_IsPublished_Is_Empty()
        {
            var model = new Article { IsPublished = false };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.IsPublished);
        }

        [Fact]
        public void Should_Not_Have_Error_When_IsPublished_Is_Valid()
        {
            var model = new Article { IsPublished = true };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.IsPublished);
        }

        [Fact]
        public void Should_Have_Error_When_IsDeleted_Is_Empty()
        {
            var model = new Article { IsDeleted = false };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.IsDeleted);
        }

        [Fact]
        public void Should_Not_Have_Error_When_IsDeleted_Is_Valid()
        {
            var model = new Article { IsDeleted = true };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.IsDeleted);
        }

        //////[Fact]
        //////public void Should_Have_Error_When_Category_Is_Empty()
        //////{
        //////    var model = new Article { Category = string.Empty };
        //////    var result = _validator.TestValidate(model);
        //////    result.ShouldHaveValidationErrorFor(x => x.Category);
        //////}

        [Fact]
        public void Should_Not_Have_Error_When_Category_Is_Valid()
        {
            var model = new Article { Category = "Valid Category" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Category);
        }
    }
}
