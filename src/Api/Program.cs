using Api.Features.Tasks.Create;
using Api.Features.Tasks.Get;
using Api.Features.Tasks.List;
using Api.Features.Tasks.Search;
using Api.Features.Tasks.Today;
using Api.Infrastructure.Persistence;
using FluentValidation;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskValidator>();
builder.Services.AddSingleton<SqlConnectionFactory>();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<CreateTaskHandler>();
builder.Services.AddScoped<GetTaskHandler>();
builder.Services.AddScoped<ListTasksHandler>();
builder.Services.AddScoped<SearchTasksHandler>();
builder.Services.AddScoped<GetTodayTasksHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("DevelopmentCors");
app.UseFastEndpoints();
app.MapGet("/", () => "supreme-train API scaffold");

app.Run();
