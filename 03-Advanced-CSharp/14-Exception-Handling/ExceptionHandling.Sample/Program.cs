// Exception Handling Examples

// 1. Basic Try-Catch
Console.WriteLine("=== Basic Try-Catch ===");
try
{
    int result = Divide(10, 0);
    Console.WriteLine($"Result: {result}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
Console.WriteLine();

// 2. Multiple Catch Blocks
Console.WriteLine("=== Multiple Catch Blocks ===");
try
{
    int[] numbers = { 1, 2, 3 };
    Console.WriteLine($"Number at index 5: {numbers[5]}");
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine($"Index Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"General Error: {ex.Message}");
}
Console.WriteLine();

// 3. Finally Block
Console.WriteLine("=== Finally Block ===");
try
{
    Console.WriteLine("Executing try block");
    throw new InvalidOperationException("Something went wrong");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}
finally
{
    Console.WriteLine("Finally block always executes");
}
Console.WriteLine();

// 4. Throwing Exceptions
Console.WriteLine("=== Throwing Exceptions ===");
try
{
    ValidateAge(-5);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}
Console.WriteLine();

// 5. Custom Exception
Console.WriteLine("=== Custom Exception ===");
try
{
    Withdraw(100, 50);
    Withdraw(100, 200); // This will throw
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Custom Exception: {ex.Message}");
    Console.WriteLine($"Current Balance: ${ex.CurrentBalance:F2}");
    Console.WriteLine($"Requested Amount: ${ex.RequestedAmount:F2}");
}
Console.WriteLine();

// 6. Exception Filters (when clause)
Console.WriteLine("=== Exception Filters ===");
try
{
    ProcessNumber(5);
    ProcessNumber(-5);
    ProcessNumber(0);
}
catch (ArgumentException ex) when (ex.Message.Contains("negative"))
{
    Console.WriteLine($"Negative number error: {ex.Message}");
}
catch (ArgumentException ex) when (ex.Message.Contains("zero"))
{
    Console.WriteLine($"Zero error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Other error: {ex.Message}");
}
Console.WriteLine();

// 7. Using Statement (Automatic Disposal)
Console.WriteLine("=== Using Statement ===");
using (var resource = new ManagedResource("Test Resource"))
{
    resource.DoSomething();
}
// Resource is automatically disposed here
Console.WriteLine("Resource disposed");
Console.WriteLine();

// 8. Try-Catch with Using
Console.WriteLine("=== Try-Catch with Using ===");
try
{
    using (var resource = new ManagedResource("Another Resource"))
    {
        resource.DoSomething();
        throw new Exception("Error during operation");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
// Resource is still disposed even if exception occurs
Console.WriteLine();

// 9. Inner Exceptions
Console.WriteLine("=== Inner Exceptions ===");
try
{
    try
    {
        throw new InvalidOperationException("Inner exception");
    }
    catch (InvalidOperationException innerEx)
    {
        throw new ApplicationException("Outer exception", innerEx);
    }
}
catch (ApplicationException ex)
{
    Console.WriteLine($"Outer Exception: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
    }
}
Console.WriteLine();

// 10. Exception Properties
Console.WriteLine("=== Exception Properties ===");
try
{
    throw new Exception("Test exception");
}
catch (Exception ex)
{
    Console.WriteLine($"Message: {ex.Message}");
    Console.WriteLine($"Type: {ex.GetType().Name}");
    Console.WriteLine($"Source: {ex.Source}");
    int length = ex.StackTrace?.Length ?? 0;
    Console.WriteLine($"Stack Trace: {ex.StackTrace?.Substring(0, Math.Min(100, length))}...");
}
Console.WriteLine();

// Helper Methods

static int Divide(int a, int b)
{
    if (b == 0)
    {
        throw new DivideByZeroException("Cannot divide by zero");
    }
    return a / b;
}

static void ValidateAge(int age)
{
    if (age < 0)
    {
        throw new ArgumentException("Age cannot be negative", nameof(age));
    }
    if (age > 150)
    {
        throw new ArgumentException("Age cannot exceed 150", nameof(age));
    }
    Console.WriteLine($"Valid age: {age}");
}

static void Withdraw(decimal balance, decimal amount)
{
    if (amount > balance)
    {
        throw new InsufficientFundsException(balance, amount);
    }
    Console.WriteLine($"Withdrawn ${amount:F2} from ${balance:F2}");
}

static void ProcessNumber(int number)
{
    if (number < 0)
    {
        throw new ArgumentException("Number cannot be negative");
    }
    if (number == 0)
    {
        throw new ArgumentException("Number cannot be zero");
    }
    Console.WriteLine($"Processing number: {number}");
}

// Custom Exception

public class InsufficientFundsException : Exception
{
    public decimal CurrentBalance { get; }
    public decimal RequestedAmount { get; }

    public InsufficientFundsException(decimal currentBalance, decimal requestedAmount)
        : base($"Insufficient funds. Current: ${currentBalance:F2}, Requested: ${requestedAmount:F2}")
    {
        CurrentBalance = currentBalance;
        RequestedAmount = requestedAmount;
    }
}

// Managed Resource for Using Statement

public class ManagedResource : IDisposable
{
    private string name;
    private bool disposed = false;

    public ManagedResource(string name)
    {
        this.name = name;
        Console.WriteLine($"Resource '{name}' created");
    }

    public void DoSomething()
    {
        if (disposed)
        {
            throw new ObjectDisposedException(nameof(ManagedResource));
        }
        Console.WriteLine($"Resource '{name}' is being used");
    }

    public void Dispose()
    {
        if (!disposed)
        {
            Console.WriteLine($"Resource '{name}' is being disposed");
            disposed = true;
        }
    }
}
