using FluentValidation;

namespace Api.Features.Tasks.Create;

public sealed class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Date)
            .NotEmpty();
    }
}
