// Design Patterns Examples
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryPattern.Sample;

// ========== FACTORY PATTERN ==========

// 1. Factory Pattern - Creating objects without specifying exact class
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[FILE] {message}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[CONSOLE] {message}");
    }
}

public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[DATABASE] {message}");
    }
}

public enum LoggerType
{
    File,
    Console,
    Database
}

public class LoggerFactory
{
    public static ILogger CreateLogger(LoggerType type)
    {
        return type switch
        {
            LoggerType.File => new FileLogger(),
            LoggerType.Console => new ConsoleLogger(),
            LoggerType.Database => new DatabaseLogger(),
            _ => throw new ArgumentException("Invalid logger type")
        };
    }
}

// ========== STRATEGY PATTERN ==========

// 2. Strategy Pattern - Interchangeable algorithms
public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal price);
}

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal price) => 0;
}

public class PercentageDiscountStrategy : IDiscountStrategy
{
    private readonly decimal _percentage;

    public PercentageDiscountStrategy(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal CalculateDiscount(decimal price)
    {
        return price * (_percentage / 100);
    }
}

public class FixedAmountDiscountStrategy : IDiscountStrategy
{
    private readonly decimal _amount;

    public FixedAmountDiscountStrategy(decimal amount)
    {
        _amount = amount;
    }

    public decimal CalculateDiscount(decimal price)
    {
        return Math.Min(_amount, price);
    }
}

public class PricingService
{
    private IDiscountStrategy _discountStrategy;

    public PricingService(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public void SetDiscountStrategy(IDiscountStrategy strategy)
    {
        _discountStrategy = strategy;
    }

    public decimal CalculateFinalPrice(decimal originalPrice)
    {
        var discount = _discountStrategy.CalculateDiscount(originalPrice);
        return originalPrice - discount;
    }
}

// ========== OBSERVER PATTERN ==========

// 3. Observer Pattern - One-to-many dependency
public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string message);
}

public class ObservableProduct : ISubject
{
    private readonly List<IObserver> _observers = new();
    private string _name = string.Empty;
    private decimal _price;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            Notify($"Product name changed to {value}");
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            Notify($"Product price changed to {value:C}");
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}

public class EmailNotifier : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"[EMAIL] {message}");
    }
}

public class SmsNotifier : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"[SMS] {message}");
    }
}

// ========== SINGLETON PATTERN ==========

// 4. Singleton Pattern - Single instance
public class ConfigurationManager
{
    private static ConfigurationManager? _instance;
    private static readonly object _lock = new();

    private ConfigurationManager() { }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
    }

    public string GetSetting(string key)
    {
        // In real implementation, read from config file
        return $"Value for {key}";
    }
}

// ========== REPOSITORY PATTERN (from previous file) ==========

// Repository pattern is already in RepositoryPatternExamples.cs

// ========== COMBINING PATTERNS ==========

// 5. Combining Factory and Strategy
public interface IShippingStrategy
{
    decimal CalculateShipping(decimal weight, decimal distance);
}

public class StandardShipping : IShippingStrategy
{
    public decimal CalculateShipping(decimal weight, decimal distance)
    {
        return weight * 0.5m + distance * 0.1m;
    }
}

public class ExpressShipping : IShippingStrategy
{
    public decimal CalculateShipping(decimal weight, decimal distance)
    {
        return weight * 1.0m + distance * 0.2m;
    }
}

public class ShippingStrategyFactory
{
    public static IShippingStrategy CreateStrategy(string type)
    {
        return type.ToLower() switch
        {
            "standard" => new StandardShipping(),
            "express" => new ExpressShipping(),
            _ => throw new ArgumentException("Invalid shipping type")
        };
    }
}

public class ShippingService
{
    private IShippingStrategy _strategy;

    public ShippingService(string shippingType)
    {
        _strategy = ShippingStrategyFactory.CreateStrategy(shippingType);
    }

    public decimal CalculateShippingCost(decimal weight, decimal distance)
    {
        return _strategy.CalculateShipping(weight, distance);
    }
}

// ========== BUILDER PATTERN ==========

// 6. Builder Pattern - Constructing complex objects
public class ProductBuilder
{
    private string _name = string.Empty;
    private decimal _price;
    private string _category = string.Empty;
    private string _description = string.Empty;

    public ProductBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProductBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public ProductBuilder WithCategory(string category)
    {
        _category = category;
        return this;
    }

    public ProductBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public Product Build()
    {
        // Product class is defined in RepositoryPatternExamples.cs
        return new Product
        {
            Name = _name,
            Price = _price,
            Category = _category
        };
    }
}

// Usage: var product = new ProductBuilder().WithName("Laptop").WithPrice(999.99m).WithCategory("Electronics").Build();

// ========== ADAPTER PATTERN ==========

// 7. Adapter Pattern - Making incompatible interfaces work together
public interface IModernPaymentProcessor
{
    bool ProcessPayment(decimal amount);
}

public class LegacyPaymentSystem
{
    public bool Pay(decimal amount)
    {
        Console.WriteLine($"Legacy payment: ${amount}");
        return true;
    }
}

public class PaymentAdapter : IModernPaymentProcessor
{
    private readonly LegacyPaymentSystem _legacySystem;

    public PaymentAdapter(LegacyPaymentSystem legacySystem)
    {
        _legacySystem = legacySystem;
    }

    public bool ProcessPayment(decimal amount)
    {
        return _legacySystem.Pay(amount);
    }
}

