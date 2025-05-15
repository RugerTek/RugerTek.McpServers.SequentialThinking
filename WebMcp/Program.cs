using Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<SequentialThinkingServer>();
builder.Services.AddSingleton<SequentialThinkingServerSessions>();

builder.Services.AddMcpServer()
    .WithToolsFromAssembly()
    .WithPromptsFromAssembly()
    .WithHttpTransport()
    .WithStdioServerTransport();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Mcp Server is running");
app.MapGet("/ping", () => "pong");

app.MapMcp();

app.Run();