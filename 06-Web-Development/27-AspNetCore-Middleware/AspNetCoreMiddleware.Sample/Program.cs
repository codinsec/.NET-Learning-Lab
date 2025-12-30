// ASP.NET Core Middleware Examples
using AspNetCoreMiddleware.Sample.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// Middleware Pipeline Examples

// 1. Custom Logging Middleware
app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;
    Console.WriteLine($"[{startTime:HH:mm:ss}] Request: {context.Request.Method} {context.Request.Path}");

    await next();

    var duration = DateTime.UtcNow - startTime;
    Console.WriteLine($"[{DateTime.UtcNow:HH:mm:ss}] Response: {context.Response.StatusCode} (Duration: {duration.TotalMilliseconds}ms)");
});

// 2. Custom Header Middleware
app.Use(async (context, next) =>
{
    context.Response.Headers["X-Custom-Header"] = "Learning-Lab";
    await next();
});

// 3. Built-in Middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// 4. Custom Exception Handling Middleware
app.UseMiddleware<AspNetCoreMiddleware.Sample.Middleware.ExceptionHandlingMiddleware>();

// 5. Custom Request Timing Middleware
app.UseMiddleware<AspNetCoreMiddleware.Sample.Middleware.RequestTimingMiddleware>();

app.MapControllers();

// Minimal API endpoints for testing
app.MapGet("/", () => "Hello from Middleware Example!");
app.MapGet("/error", (HttpContext context) => throw new Exception("Test exception"));
app.MapGet("/slow", async (HttpContext context) =>
{
    await Task.Delay(1000);
    return "This request took 1 second";
});

app.Run();
