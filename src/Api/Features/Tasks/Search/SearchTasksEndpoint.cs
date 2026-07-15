using FastEndpoints;

namespace Api.Features.Tasks.Search;

public sealed class SearchTasksEndpoint : Endpoint<SearchTasksRequest, IReadOnlyList<SearchTasksResponse>>
{
    private readonly SearchTasksHandler _handler;

    public SearchTasksEndpoint(SearchTasksHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get("/tasks");
        AllowAnonymous();
        Description(x => x.Produces<IReadOnlyList<SearchTasksResponse>>(200));
    }

    public override async Task HandleAsync(SearchTasksRequest request, CancellationToken cancellationToken)
    {
        var response = await _handler.HandleAsync(request, cancellationToken);
        HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
    }
}
