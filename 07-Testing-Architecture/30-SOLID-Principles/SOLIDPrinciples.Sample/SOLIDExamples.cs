// SOLID Principles Examples

namespace SOLIDPrinciples.Sample;

// ========== SINGLE RESPONSIBILITY PRINCIPLE (SRP) ==========

// ❌ Violation: Class has multiple responsibilities
public class BadUserService
{
    public void CreateUser(string name, string email) { }
    public void SendEmail(string to, string subject, string body) { }
    public void LogError(string message) { }
}

// ✅ Following SRP: Separate classes for each responsibility
public class UserService
{
    private readonly IEmailService _emailService;
    private readonly ILogger _logger;

    public UserService(IEmailService emailService, ILogger logger)
    {
        _emailService = emailService;
        _logger = logger;
    }

    public void CreateUser(string name, string email)
    {
        // User creation logic only
        _logger.Log($"User {name} created");
        _emailService.SendEmail(email, "Welcome", "Welcome to our service!");
    }
}

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        // Email sending logic only
        Console.WriteLine($"Email sent to {to}: {subject}");
    }
}

public interface ILogger
{
    void Log(string message);
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        // Logging logic only
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}

// ========== OPEN/CLOSED PRINCIPLE (OCP) ==========

// ❌ Violation: Modifying existing code to add new features
public class BadPaymentProcessor
{
    public void ProcessPayment(string paymentType, decimal amount)
    {
        if (paymentType == "CreditCard")
        {
            // Credit card processing
        }
        else if (paymentType == "PayPal")
        {
            // PayPal processing
        }
        // Adding new payment type requires modifying this class
    }
}

// ✅ Following OCP: Open for extension, closed for modification
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} via Credit Card");
    }
}

public class PayPalProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} via PayPal");
    }
}

public class PaymentService
{
    private readonly IPaymentProcessor _processor;

    public PaymentService(IPaymentProcessor processor)
    {
        _processor = processor;
    }

    public void ProcessPayment(decimal amount)
    {
        _processor.ProcessPayment(amount);
    }
}

// ========== LISKOV SUBSTITUTION PRINCIPLE (LSP) ==========

// ❌ Violation: Subclass that doesn't properly substitute base class
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int Area => Width * Height;
}

public class BadSquare : Rectangle
{
    public override int Width
    {
        set { base.Width = value; base.Height = value; }
    }

    public override int Height
    {
        set { base.Width = value; base.Height = value; }
    }
}

// ✅ Following LSP: Proper inheritance hierarchy
public abstract class Shape
{
    public abstract int Area { get; }
}

public class GoodRectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public override int Area => Width * Height;
}

public class GoodSquare : Shape
{
    public int Side { get; set; }
    public override int Area => Side * Side;
}

// ========== INTERFACE SEGREGATION PRINCIPLE (ISP) ==========

// ❌ Violation: Fat interface forcing clients to implement unused methods
public interface IBadWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class Human : IBadWorker
{
    public void Work() { }
    public void Eat() { }
    public void Sleep() { }
}

public class Robot : IBadWorker
{
    public void Work() { }
    public void Eat() { throw new NotImplementedException(); } // Robot doesn't eat!
    public void Sleep() { throw new NotImplementedException(); } // Robot doesn't sleep!
}

// ✅ Following ISP: Segregated interfaces
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class GoodHuman : IWorkable, IEatable, ISleepable
{
    public void Work() { Console.WriteLine("Human working"); }
    public void Eat() { Console.WriteLine("Human eating"); }
    public void Sleep() { Console.WriteLine("Human sleeping"); }
}

public class GoodRobot : IWorkable
{
    public void Work() { Console.WriteLine("Robot working"); }
}

// ========== DEPENDENCY INVERSION PRINCIPLE (DIP) ==========

// ❌ Violation: High-level module depends on low-level module
public class BadOrderService
{
    private readonly SqlServerDatabase _database; // Direct dependency on concrete class

    public BadOrderService()
    {
        _database = new SqlServerDatabase();
    }

    public void SaveOrder(Order order)
    {
        _database.Save(order);
    }
}

public class SqlServerDatabase
{
    public void Save(object data) { }
}

// ✅ Following DIP: Depend on abstractions
public interface IDatabase
{
    void Save(object data);
}

public class SqlServerDatabaseGood : IDatabase
{
    public void Save(object data)
    {
        Console.WriteLine("Saving to SQL Server");
    }
}

public class MongoDatabase : IDatabase
{
    public void Save(object data)
    {
        Console.WriteLine("Saving to MongoDB");
    }
}

public class GoodOrderService
{
    private readonly IDatabase _database; // Depend on abstraction

    public GoodOrderService(IDatabase database)
    {
        _database = database;
    }

    public void SaveOrder(Order order)
    {
        _database.Save(order);
    }
}

// ========== COMPLETE EXAMPLE: E-Commerce System Following SOLID ==========

// SRP: Separate responsibilities
public interface IProductRepository
{
    Product? GetById(int id);
    void Save(Product product);
}

public interface IOrderRepository
{
    void Save(Order order);
}

public interface INotificationService
{
    void SendOrderConfirmation(Order order);
}

// OCP: Extensible payment processors
public interface IPaymentMethod
{
    bool ProcessPayment(decimal amount);
}

public class CreditCardPayment : IPaymentMethod
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} via Credit Card");
        return true;
    }
}

public class BankTransferPayment : IPaymentMethod
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} via Bank Transfer");
        return true;
    }
}

// ISP: Segregated interfaces
public interface IReadableRepository<T>
{
    T? GetById(int id);
    IEnumerable<T> GetAll();
}

public interface IWritableRepository<T>
{
    void Save(T entity);
    void Delete(int id);
}

// DIP: Depend on abstractions
public class ECommerceService
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly INotificationService _notificationService;
    private readonly IPaymentMethod _paymentMethod;

    public ECommerceService(
        IProductRepository productRepository,
        IOrderRepository orderRepository,
        INotificationService notificationService,
        IPaymentMethod paymentMethod)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _notificationService = notificationService;
        _paymentMethod = paymentMethod;
    }

    public bool ProcessOrder(int productId, decimal amount)
    {
        var product = _productRepository.GetById(productId);
        if (product == null)
            return false;

        if (_paymentMethod.ProcessPayment(amount))
        {
            var order = new Order { ProductId = productId, Amount = amount };
            _orderRepository.Save(order);
            _notificationService.SendOrderConfirmation(order);
            return true;
        }

        return false;
    }
}

// Entity Classes

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal Amount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
}

