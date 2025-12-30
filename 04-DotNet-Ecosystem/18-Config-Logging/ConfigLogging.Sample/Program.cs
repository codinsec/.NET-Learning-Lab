// Configuration & Logging Examples
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// 1. Basic Configuration
Console.WriteLine("=== Basic Configuration ===");
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

var appName = configuration["AppSettings:AppName"];
var version = configuration["AppSettings:Version"];
var environment = configuration["AppSettings:Environment"];

Console.WriteLine($"App Name: {appName}");
Console.WriteLine($"Version: {version}");
Console.WriteLine($"Environment: {environment}");
Console.WriteLine();

// 2. Configuration Sections
Console.WriteLine("=== Configuration Sections ===");
var dbSection = configuration.GetSection("Database");
var connectionString = dbSection["ConnectionString"];
var timeout = dbSection["Timeout"];

Console.WriteLine($"Connection String: {connectionString}");
Console.WriteLine($"Timeout: {timeout}");
Console.WriteLine();

// 3. Strongly-Typed Configuration
Console.WriteLine("=== Strongly-Typed Configuration ===");
var appSettings = new AppSettings();
configuration.GetSection("AppSettings").Bind(appSettings);

Console.WriteLine($"App Name: {appSettings.AppName}");
Console.WriteLine($"Version: {appSettings.Version}");
Console.WriteLine($"Environment: {appSettings.Environment}");
Console.WriteLine();

// 4. Environment Variables
Console.WriteLine("=== Environment Variables ===");
Environment.SetEnvironmentVariable("CUSTOM_SETTING", "Value from Environment");
var customSetting = configuration["CUSTOM_SETTING"] ?? Environment.GetEnvironmentVariable("CUSTOM_SETTING");
Console.WriteLine($"Custom Setting: {customSetting}");
Console.WriteLine();

// 5. Basic Logging
Console.WriteLine("=== Basic Logging ===");
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddConsole()
        .SetMinimumLevel(LogLevel.Information);
});

var logger = loggerFactory.CreateLogger<Program>();

logger.LogTrace("This is a Trace message");
logger.LogDebug("This is a Debug message");
logger.LogInformation("This is an Information message");
logger.LogWarning("This is a Warning message");
logger.LogError("This is an Error message");
logger.LogCritical("This is a Critical message");
Console.WriteLine();

// 6. Logging with Categories
Console.WriteLine("=== Logging with Categories ===");
var categoryLogger = loggerFactory.CreateLogger("MyCategory");
categoryLogger.LogInformation("Message from MyCategory");
Console.WriteLine();

// 7. Structured Logging
Console.WriteLine("=== Structured Logging ===");
logger.LogInformation("User {UserId} logged in at {LoginTime}", 12345, DateTime.Now);
logger.LogWarning("Failed to process order {OrderId} after {RetryCount} attempts", "ORD-001", 3);
logger.LogError("Database connection failed. Server: {Server}, Database: {Database}", "localhost", "MyDB");
Console.WriteLine();

// 8. Logging with Exception
Console.WriteLine("=== Logging with Exception ===");
try
{
    throw new InvalidOperationException("Something went wrong");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while processing");
}
Console.WriteLine();

// 9. Logging Levels Configuration
Console.WriteLine("=== Logging Levels Configuration ===");
var logLevelConfig = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var loggingFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddConfiguration(logLevelConfig.GetSection("Logging"))
        .AddConsole();
});

var configuredLogger = loggingFactory.CreateLogger<Program>();
configuredLogger.LogTrace("Trace - should not appear");
configuredLogger.LogDebug("Debug - should not appear");
configuredLogger.LogInformation("Information - should appear");
configuredLogger.LogWarning("Warning - should appear");
Console.WriteLine();

// 10. Scoped Logging
Console.WriteLine("=== Scoped Logging ===");
using (logger.BeginScope("Transaction {TransactionId}", Guid.NewGuid()))
{
    logger.LogInformation("Starting transaction");
    logger.LogInformation("Processing payment");
    logger.LogInformation("Transaction completed");
}
Console.WriteLine();

// Configuration Classes

public class AppSettings
{
    public string AppName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Environment { get; set; } = string.Empty;
}

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public int Timeout { get; set; }
}
