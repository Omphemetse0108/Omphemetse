var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => "Student Services API v1.0");
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.MapControllers();

app.Run();

public partial class Program { }