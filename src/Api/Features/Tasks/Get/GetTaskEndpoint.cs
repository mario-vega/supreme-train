using FastEndpoints;

namespace Api.Features.Tasks.Get;

public sealed class GetTaskEndpoint : Endpoint<GetTaskRequest, GetTaskResponse>
{
    private readonly GetTaskHandler _handler;

    public GetTaskEndpoint(GetTaskHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get("/tasks/{id:guid}");
        AllowAnonymous();
        Description(x => x
            .Produces<GetTaskResponse>(200)
            .ProducesProblem(404));
    }

    public override async Task HandleAsync(GetTaskRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _handler.HandleAsync(request, cancellationToken);
            HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        }
        catch (InvalidOperationException)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await HttpContext.Response.WriteAsJsonAsync(new { message = "Task not found." }, cancellationToken);
        }
    }
}
