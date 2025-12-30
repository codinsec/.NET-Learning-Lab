// ASP.NET Core Web API Examples
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Minimal API Examples
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// GET endpoint
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return Results.Ok(forecast);
})
.WithName("GetWeatherForecast")
.WithTags("Weather")
.Produces<WeatherForecast[]>(StatusCodes.Status200OK);

// GET with parameter
app.MapGet("/weatherforecast/{days}", (int days) =>
{
    if (days < 1 || days > 14)
        return Results.BadRequest("Days must be between 1 and 14");

    var forecast = Enumerable.Range(1, days).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return Results.Ok(forecast);
})
.WithName("GetWeatherForecastByDays")
.WithTags("Weather")
.Produces<WeatherForecast[]>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);

// POST endpoint
app.MapPost("/weatherforecast", (WeatherForecast forecast) =>
{
    // In a real app, you would save to database
    return Results.Created($"/weatherforecast/{forecast.Date}", forecast);
})
.WithName("CreateWeatherForecast")
.WithTags("Weather")
.Produces<WeatherForecast>(StatusCodes.Status201Created)
.Accepts<WeatherForecast>("application/json");

app.Run();

// Models
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
