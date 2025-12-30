// Unit Testing Examples with xUnit and Moq
using Moq;

namespace UnitTesting.Sample;

// 1. Basic Unit Test
public class CalculatorTests
{
    [Fact]
    public void Add_ShouldReturnSum_WhenGivenTwoNumbers()
    {
        // Arrange
        var calculator = new Calculator();
        int a = 5;
        int b = 3;

        // Act
        var result = calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Subtract_ShouldReturnDifference_WhenGivenTwoNumbers()
    {
        // Arrange
        var calculator = new Calculator();
        int a = 10;
        int b = 4;

        // Act
        var result = calculator.Subtract(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(10, 5, 15)]
    [InlineData(-1, 1, 0)]
    public void Add_ShouldReturnCorrectSum_ForMultipleInputs(int a, int b, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}

// 2. Testing with Dependencies (Mocking)
public class OrderServiceTests
{
    [Fact]
    public void ProcessOrder_ShouldCallEmailService_WhenOrderIsValid()
    {
        // Arrange
        var mockEmailService = new Mock<IEmailService>();
        var orderService = new OrderService(mockEmailService.Object);
        var order = new Order { Id = 1, Total = 100.00m };

        // Act
        orderService.ProcessOrder(order);

        // Assert
        mockEmailService.Verify(x => x.SendEmail(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void ProcessOrder_ShouldNotCallEmailService_WhenOrderIsNull()
    {
        // Arrange
        var mockEmailService = new Mock<IEmailService>();
        var orderService = new OrderService(mockEmailService.Object);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => orderService.ProcessOrder(null!));
        mockEmailService.Verify(x => x.SendEmail(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()), Times.Never);
    }
}

// 3. Testing Exceptions
public class ValidationServiceTests
{
    [Fact]
    public void ValidateEmail_ShouldThrowException_WhenEmailIsInvalid()
    {
        // Arrange
        var validator = new ValidationService();
        string invalidEmail = "not-an-email";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => validator.ValidateEmail(invalidEmail));
        Assert.Contains("Invalid email", exception.Message);
    }

    [Fact]
    public void ValidateEmail_ShouldNotThrow_WhenEmailIsValid()
    {
        // Arrange
        var validator = new ValidationService();
        string validEmail = "test@example.com";

        // Act
        var exception = Record.Exception(() => validator.ValidateEmail(validEmail));

        // Assert
        Assert.Null(exception);
    }
}

// 4. Testing Collections
public class ProductServiceTests
{
    [Fact]
    public void GetProducts_ShouldReturnAllProducts_WhenCalled()
    {
        // Arrange
        var service = new ProductService();
        service.AddProduct(new Product { Id = 1, Name = "Product 1" });
        service.AddProduct(new Product { Id = 2, Name = "Product 2" });

        // Act
        var products = service.GetProducts();

        // Assert
        Assert.Equal(2, products.Count());
        Assert.Contains(products, p => p.Name == "Product 1");
        Assert.Contains(products, p => p.Name == "Product 2");
    }
}

// Helper Classes for Testing

public class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
}

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
}

public class OrderService
{
    private readonly IEmailService _emailService;

    public OrderService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void ProcessOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        // Process order logic
        _emailService.SendEmail("customer@example.com", "Order Confirmation", $"Order {order.Id} processed");
    }
}

public class ValidationService
{
    public void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new ArgumentException("Invalid email format", nameof(email));
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ProductService
{
    private readonly List<Product> _products = new();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}
