using FastEndpoints;

namespace Api.Features.Tasks.Today;

public sealed class GetTodayTasksEndpoint : EndpointWithoutRequest<IReadOnlyList<GetTodayTasksResponse>>
{
    private readonly GetTodayTasksHandler _handler;

    public GetTodayTasksEndpoint(GetTodayTasksHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get("/tasks/today");
        AllowAnonymous();
        Description(x => x.Produces<IReadOnlyList<GetTodayTasksResponse>>(200));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var response = await _handler.HandleAsync(cancellationToken);
        HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
    }
}
