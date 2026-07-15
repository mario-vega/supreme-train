using FastEndpoints;

namespace Api.Features.Tasks.List;

public sealed class ListTasksEndpoint : EndpointWithoutRequest<IReadOnlyList<ListTasksResponse>>
{
    private readonly ListTasksHandler _handler;

    public ListTasksEndpoint(ListTasksHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get("/tasks");
        AllowAnonymous();
        Description(x => x.Produces<IReadOnlyList<ListTasksResponse>>(200));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var response = await _handler.HandleAsync(cancellationToken);
        HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
    }
}
