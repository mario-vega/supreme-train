using FastEndpoints;
using FluentValidation;

namespace Api.Features.Tasks.Create;

public sealed class CreateTaskEndpoint : Endpoint<CreateTaskRequest, CreateTaskResponse>
{
    private readonly CreateTaskHandler _handler;
    private readonly IValidator<CreateTaskRequest> _validator;

    public CreateTaskEndpoint(CreateTaskHandler handler, IValidator<CreateTaskRequest> validator)
    {
        _handler = handler;
        _validator = validator;
    }

    public override void Configure()
    {
        Post("/tasks");
        AllowAnonymous();
        Description(x => x
            .Produces<CreateTaskResponse>(201)
            .ProducesValidationProblem(400));
    }

    public override async Task HandleAsync(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            foreach (var failure in validationResult.Errors)
            {
                AddError(failure);
            }

            ThrowError("One or more validation errors occurred.");
        }

        var response = await _handler.HandleAsync(request, cancellationToken);

        HttpContext.Response.StatusCode = StatusCodes.Status201Created;
        HttpContext.Response.Headers.Location = $"/tasks/{response.Id}";
        await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
    }
}
