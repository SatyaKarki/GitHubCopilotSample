using Blog.API.Model;
using Blog.API.Validations;
using FluentValidation.TestHelper;

namespace Blog.API.Tests.Validator;

public class ArticleValidatorTests
{
    private readonly ArticleValidator _validator;

    public ArticleValidatorTests()
    {
        _validator = new ArticleValidator();
    }

    //write unit test for ID property using Theory and Inline data
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void IdIsInvalid(int id)
    {
        //Arrange
        var model = new Article { Id = id };
        //Act
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    public void IdIsValid(int id)
    {
        //Arrange
        var model = new Article { Id = id };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(x => x.Id);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("A long title that exceeds the maximum length of one hundred characters. This is just a test to check the validation rules.")]
    public void TitleIsInvalid(string title)
    {
        //Arrange
        var model = new Article { Title = title };
        //Act
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    //write unit tests for valid title
    [Theory]
    [InlineData("Valid Title")]
    [InlineData("Another Valid Title")]
    [InlineData("Title with 100 characters: AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
    public void TitleIsValid(string title)
    {
        //Arrange
        var model = new Article { Title = title };
        //Act
        var result = _validator.TestValidate(model);
        // Assert
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
    public void Should_Have_Error_When_Content_Is_Too_Short()
    {
        var model = new Article { Content = new string('A', 99) };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Content);
    }

    [Fact]
    public void Should_Have_Error_When_Content_Is_Too_Long()
    {
        var model = new Article { Content = new string('A', 1001) };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Content);
    }

    [Fact]
    public void Should_Have_Error_When_Author_Is_Empty()
    {
        var model = new Article { Author = string.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Author);
    }

    [Fact]
    public void Should_Have_Error_When_Author_Contains_Invalid_Characters()
    {
        var model = new Article { Author = "Author123!" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Author);
    }

    [Fact]
    public void Should_Have_Error_When_CreatedAt_Is_Invalid()
    {
        var model = new Article { CreatedAt = DateTime.MinValue };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.CreatedAt);
    }

    [Fact]
    public void Should_Have_Error_When_UpdatedAt_Is_Invalid()
    {
        var model = new Article { UpdatedAt = DateTime.MinValue };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.UpdatedAt);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Article_Is_Valid()
    {
        var model = new Article
        {
            Id = 1,
            Title = "Valid Title",
            Content = new string('A', 500),
            Author = "Valid Author",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsPublished = true,
            IsDeleted = true,
            Tags = new List<string> { "Tag1", "Tag2" },
            Category = "Valid Category"
        };

        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}