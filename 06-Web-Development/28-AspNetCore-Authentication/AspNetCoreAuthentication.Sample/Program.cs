// ASP.NET Core Authentication Examples
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"] ?? "YourSuperSecretKeyThatShouldBeAtLeast32CharactersLong!";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"] ?? "LearningLab",
        ValidAudience = jwtSettings["Audience"] ?? "LearningLabUsers",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Authentication Endpoints
app.MapPost("/api/auth/login", (LoginRequest request) =>
{
    // In a real app, validate credentials against database
    if (request.Username == "admin" && request.Password == "password")
    {
        var token = GenerateJwtToken(request.Username, "Admin");
        return Results.Ok(new { token });
    }
    return Results.Unauthorized();
})
.WithName("Login")
.WithTags("Authentication")
.Produces<string>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status401Unauthorized);

// Protected Endpoint
app.MapGet("/api/products/protected", [Authorize] () =>
{
    return Results.Ok(new[]
    {
        new { Id = 1, Name = "Product 1", Price = 99.99m },
        new { Id = 2, Name = "Product 2", Price = 149.99m }
    });
})
.WithName("GetProtectedProducts")
.WithTags("Products")
.RequireAuthorization()
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status401Unauthorized);

// Public Endpoint
app.MapGet("/api/products", () =>
{
    return Results.Ok(new[]
    {
        new { Id = 1, Name = "Public Product 1", Price = 49.99m },
        new { Id = 2, Name = "Public Product 2", Price = 79.99m }
    });
})
.WithName("GetPublicProducts")
.WithTags("Products")
.Produces(StatusCodes.Status200OK);

app.Run();

// Helper Methods
string GenerateJwtToken(string username, string role)
{
    var claims = new[]
    {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, role),
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: "LearningLab",
        audience: "LearningLabUsers",
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}

// Models
public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
