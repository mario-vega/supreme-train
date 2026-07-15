using Api.Features.Tasks;
using Api.Features.Tasks.Create;
using FluentValidation.TestHelper;

namespace Api.Tests.Features.Tasks.Create;

public class CreateTaskValidatorTests
{
    private readonly CreateTaskValidator _validator = new();

    [Fact]
    public void CreateTaskValidator_Should_HaveError_When_TitleIsEmpty()
    {
        var model = new CreateTaskRequest { Title = string.Empty, Date = DateTime.UtcNow, Priority = 2 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage("'Title' must not be empty.");
    }

    [Fact]
    public void CreateTaskValidator_Should_HaveError_When_TitleExceeds100Characters()
    {
        var model = new CreateTaskRequest { Title = new string('a', 101), Date = DateTime.UtcNow, Priority = 2 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage("The length of 'Title' must be 100 characters or fewer. You entered 101 characters.");
    }

    [Fact]
    public void CreateTaskValidator_Should_HaveError_When_DateIsEmpty()
    {
        var model = new CreateTaskRequest { Title = "Test", Date = default, Priority = 2 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Date)
            .WithErrorMessage("'Date' must not be empty.");
    }

    [Fact]
    public void CreateTaskValidator_Should_NotHaveError_When_RequestIsValid()
    {
        var model = new CreateTaskRequest { Title = "Test", Date = DateTime.UtcNow, Priority = 2 };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
