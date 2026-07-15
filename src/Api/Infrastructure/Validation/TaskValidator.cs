using FluentValidation;

namespace Api.Infrastructure.Validation;

public sealed class TaskValidator : AbstractValidator<Features.Tasks.TaskItem>
{
    public TaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Date)
            .NotEmpty();
    }
}
