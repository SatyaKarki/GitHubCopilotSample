using Blog.API.Model;
using Blog.API.Validations;
using FluentValidation.TestHelper;

namespace Blog.API.Tests.Validations
{
    //mixed with Fact and Theory
    public class ArticleValidatorTests1
    {
        private readonly ArticleValidator _validator = new();

        // ID Tests
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_When_Id_Is_Zero_Or_Negative(int id)
        {
            //Arrange
            var model = new Article { Id = id };
            //Act
            var result = _validator.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Id_Is_Positive()
        {
            var model = new Article { Id = 1 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        // Title Tests
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Have_Error_When_Title_Is_Empty(string? title)
        {
            var model = new Article { Title = title! };
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

        // Content Tests
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("short content")]
        public void Should_Have_Error_When_Content_Is_Too_Short(string? content)
        {
            var model = new Article { Content = content ?? "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Content);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Content_Is_Valid()
        {
            var model = new Article { Content = new string('a', 150) };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Content);
        }

        // Author Tests
        [Theory]
        [InlineData("")]
        [InlineData("1234")]
        [InlineData("John@Doe")]
        public void Should_Have_Error_When_Author_Is_Invalid(string author)
        {
            var model = new Article { Author = author };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Author);
        }

        [Theory]
        [InlineData("John")]
        [InlineData("Jane Doe")]
        public void Should_Not_Have_Error_When_Author_Is_Valid(string author)
        {
            var model = new Article { Author = author };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Author);
        }

        // CreatedAt Tests
        [Fact]
        public void Should_Have_Error_When_CreatedAt_Is_Default()
        {
            var model = new Article { CreatedAt = DateTime.MinValue };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CreatedAt);
        }

        [Fact]
        public void Should_Not_Have_Error_When_CreatedAt_Is_Valid()
        {
            var model = new Article { CreatedAt = DateTime.UtcNow };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.CreatedAt);
        }

        // UpdatedAt Tests
        [Fact]
        public void Should_Have_Error_When_UpdatedAt_Is_Default()
        {
            var model = new Article { UpdatedAt = DateTime.MinValue };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.UpdatedAt);
        }

        [Fact]
        public void Should_Not_Have_Error_When_UpdatedAt_Is_Valid()
        {
            var model = new Article { UpdatedAt = DateTime.UtcNow };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.UpdatedAt);
        }

        // IsPublished Tests
        [Fact]
        public void Should_Not_Have_Error_When_IsPublished_Is_True_Or_False()
        {
            var model1 = new Article { IsPublished = true };
            var model2 = new Article { IsPublished = false };

            _validator.TestValidate(model1).ShouldNotHaveValidationErrorFor(x => x.IsPublished);
            _validator.TestValidate(model2).ShouldNotHaveValidationErrorFor(x => x.IsPublished);
        }

        // IsDeleted Tests
        [Fact]
        public void Should_Not_Have_Error_When_IsDeleted_Is_True_Or_False()
        {
            var model1 = new Article { IsDeleted = true };
            var model2 = new Article { IsDeleted = false };

            _validator.TestValidate(model1).ShouldNotHaveValidationErrorFor(x => x.IsDeleted);
            _validator.TestValidate(model2).ShouldNotHaveValidationErrorFor(x => x.IsDeleted);
        }
    }

}
