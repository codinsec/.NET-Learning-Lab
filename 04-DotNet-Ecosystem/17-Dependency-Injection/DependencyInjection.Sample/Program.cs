// Dependency Injection Examples
using Microsoft.Extensions.DependencyInjection;

// 1. Basic Service Registration
Console.WriteLine("=== Basic Service Registration ===");
var services = new ServiceCollection();

// Register services
services.AddTransient<IEmailService, EmailService>();
services.AddTransient<IUserService, UserService>();

// Build service provider
var serviceProvider = services.BuildServiceProvider();

// Resolve and use service
var userService = serviceProvider.GetRequiredService<IUserService>();
userService.SendWelcomeEmail("john@example.com");
Console.WriteLine();

// 2. Service Lifetimes
Console.WriteLine("=== Service Lifetimes ===");
var lifetimeServices = new ServiceCollection();

// Transient - new instance every time
lifetimeServices.AddTransient<ITransientService, TransientService>();

// Scoped - one instance per scope
lifetimeServices.AddScoped<IScopedService, ScopedService>();

// Singleton - single instance for app lifetime
lifetimeServices.AddSingleton<ISingletonService, SingletonService>();

var lifetimeProvider = lifetimeServices.BuildServiceProvider();

// Demonstrate Transient
var transient1 = lifetimeProvider.GetRequiredService<ITransientService>();
var transient2 = lifetimeProvider.GetRequiredService<ITransientService>();
Console.WriteLine($"Transient instances equal: {transient1 == transient2}");

// Demonstrate Scoped
using (var scope = lifetimeProvider.CreateScope())
{
    var scoped1 = scope.ServiceProvider.GetRequiredService<IScopedService>();
    var scoped2 = scope.ServiceProvider.GetRequiredService<IScopedService>();
    Console.WriteLine($"Scoped instances equal (same scope): {scoped1 == scoped2}");
}

using (var scope2 = lifetimeProvider.CreateScope())
{
    var scoped3 = scope2.ServiceProvider.GetRequiredService<IScopedService>();
    var scoped1 = lifetimeProvider.GetRequiredService<IScopedService>(); // Different scope
    Console.WriteLine($"Scoped instances equal (different scope): {scoped1 == scoped3}");
}

// Demonstrate Singleton
var singleton1 = lifetimeProvider.GetRequiredService<ISingletonService>();
var singleton2 = lifetimeProvider.GetRequiredService<ISingletonService>();
Console.WriteLine($"Singleton instances equal: {singleton1 == singleton2}");
Console.WriteLine();

// 3. Constructor Injection
Console.WriteLine("=== Constructor Injection ===");
var injectionServices = new ServiceCollection();
injectionServices.AddTransient<ILogger, ConsoleLogger>();
injectionServices.AddTransient<IOrderService, OrderService>();

var injectionProvider = injectionServices.BuildServiceProvider();
var orderService = injectionProvider.GetRequiredService<IOrderService>();
orderService.ProcessOrder("ORD-001");
Console.WriteLine();

// 4. Multiple Implementations
Console.WriteLine("=== Multiple Implementations ===");
var multiServices = new ServiceCollection();
multiServices.AddTransient<IPaymentProcessor, CreditCardProcessor>();
multiServices.AddTransient<IPaymentProcessor, PayPalProcessor>();

var multiProvider = multiServices.BuildServiceProvider();
var processors = multiProvider.GetServices<IPaymentProcessor>();
Console.WriteLine($"Registered payment processors: {processors.Count()}");
foreach (var processor in processors)
{
    processor.ProcessPayment(100.00m);
}
Console.WriteLine();

// 5. Service with Dependencies
Console.WriteLine("=== Service with Dependencies ===");
var depServices = new ServiceCollection();
depServices.AddTransient<IDatabase, Database>();
depServices.AddTransient<ICache, Cache>();
depServices.AddTransient<IDataService, DataService>();

var depProvider = depServices.BuildServiceProvider();
var dataService = depProvider.GetRequiredService<IDataService>();
dataService.GetData("key1");
Console.WriteLine();

// Interface and Implementation Definitions

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine($"Email sent to {to}: {subject}");
    }
}

public interface IUserService
{
    void SendWelcomeEmail(string email);
}

public class UserService : IUserService
{
    private readonly IEmailService _emailService;

    public UserService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void SendWelcomeEmail(string email)
    {
        _emailService.SendEmail(email, "Welcome!", "Welcome to our service!");
    }
}

// Service Lifetimes

public interface ITransientService
{
    string GetId();
}

public class TransientService : ITransientService
{
    private readonly string _id = Guid.NewGuid().ToString();
    public string GetId() => _id;
}

public interface IScopedService
{
    string GetId();
}

public class ScopedService : IScopedService
{
    private readonly string _id = Guid.NewGuid().ToString();
    public string GetId() => _id;
}

public interface ISingletonService
{
    string GetId();
}

public class SingletonService : ISingletonService
{
    private readonly string _id = Guid.NewGuid().ToString();
    public string GetId() => _id;
}

// Constructor Injection

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss} - {message}");
    }
}

public interface IOrderService
{
    void ProcessOrder(string orderId);
}

public class OrderService : IOrderService
{
    private readonly ILogger _logger;

    public OrderService(ILogger logger)
    {
        _logger = logger;
    }

    public void ProcessOrder(string orderId)
    {
        _logger.Log($"Processing order: {orderId}");
        _logger.Log($"Order {orderId} processed successfully");
    }
}

// Multiple Implementations

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount:F2} via Credit Card");
    }
}

public class PayPalProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount:F2} via PayPal");
    }
}

// Service with Dependencies

public interface IDatabase
{
    string GetData(string key);
}

public class Database : IDatabase
{
    public string GetData(string key)
    {
        Console.WriteLine($"Fetching data from database for key: {key}");
        return $"Data for {key}";
    }
}

public interface ICache
{
    string? Get(string key);
    void Set(string key, string value);
}

public class Cache : ICache
{
    private readonly Dictionary<string, string> _storage = new();

    public string? Get(string key)
    {
        Console.WriteLine($"Checking cache for key: {key}");
        return _storage.TryGetValue(key, out var value) ? value : null;
    }

    public void Set(string key, string value)
    {
        Console.WriteLine($"Caching data for key: {key}");
        _storage[key] = value;
    }
}

public interface IDataService
{
    string GetData(string key);
}

public class DataService : IDataService
{
    private readonly ICache _cache;
    private readonly IDatabase _database;

    public DataService(ICache cache, IDatabase database)
    {
        _cache = cache;
        _database = database;
    }

    public string GetData(string key)
    {
        // Check cache first
        var cached = _cache.Get(key);
        if (cached != null)
        {
            Console.WriteLine("Data found in cache");
            return cached;
        }

        // If not in cache, get from database
        var data = _database.GetData(key);
        _cache.Set(key, data);
        return data;
    }
}
