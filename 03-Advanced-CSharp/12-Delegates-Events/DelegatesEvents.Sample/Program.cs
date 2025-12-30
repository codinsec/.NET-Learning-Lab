// Delegates & Events Examples

// 1. Basic Delegate
Console.WriteLine("=== Basic Delegate ===");
MathOperation add = Add;
MathOperation multiply = Multiply;

Console.WriteLine($"Add(5, 3) = {add(5, 3)}");
Console.WriteLine($"Multiply(5, 3) = {multiply(5, 3)}");
Console.WriteLine();

// 2. Multicast Delegate
Console.WriteLine("=== Multicast Delegate ===");
NotifyDelegate notify = NotifyByEmail;
notify += NotifyBySMS;
notify += NotifyByPush;

notify("System update available");
Console.WriteLine();

// 3. Func Delegate
Console.WriteLine("=== Func Delegate ===");
Func<int, int, int> addFunc = (x, y) => x + y;
Func<int, int, int> multiplyFunc = (x, y) => x * y;

Console.WriteLine($"Func Add(5, 3) = {addFunc(5, 3)}");
Console.WriteLine($"Func Multiply(5, 3) = {multiplyFunc(5, 3)}");

Func<string, int> getLength = s => s.Length;
Console.WriteLine($"Length of 'Hello': {getLength("Hello")}");
Console.WriteLine();

// 4. Action Delegate
Console.WriteLine("=== Action Delegate ===");
Action<string> printAction = message => Console.WriteLine($"Action: {message}");
Action<int, int> printSum = (x, y) => Console.WriteLine($"Sum: {x + y}");

printAction("Hello from Action!");
printSum(5, 3);
Console.WriteLine();

// 5. Events
Console.WriteLine("=== Events ===");
Button button = new Button("Click Me");

// Subscribe to event
button.Clicked += OnButtonClicked;
button.Clicked += OnButtonClickedAgain;

// Trigger event
button.Click();
Console.WriteLine();

// 6. Event with Custom EventArgs
Console.WriteLine("=== Event with Custom EventArgs ===");
TemperatureSensor sensor = new TemperatureSensor();

sensor.TemperatureChanged += OnTemperatureChanged;
sensor.TemperatureChanged += OnTemperatureChangedAgain;

sensor.SetTemperature(25.5);
sensor.SetTemperature(30.0);
Console.WriteLine();

// 7. Lambda Expressions
Console.WriteLine("=== Lambda Expressions ===");
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var evenNumbers = numbers.Where(n => n % 2 == 0);
var squared = numbers.Select(n => n * n);
var sum = numbers.Aggregate((acc, n) => acc + n);

Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");
Console.WriteLine($"Squared: {string.Join(", ", squared)}");
Console.WriteLine($"Sum: {sum}");
Console.WriteLine();

// 8. Predicate Delegate
Console.WriteLine("=== Predicate Delegate ===");
Predicate<int> isEven = n => n % 2 == 0;
Predicate<int> isPositive = n => n > 0;

List<int> testNumbers = new List<int> { -2, -1, 0, 1, 2, 3, 4 };

var even = testNumbers.FindAll(isEven);
var positive = testNumbers.FindAll(isPositive);

Console.WriteLine($"Even: {string.Join(", ", even)}");
Console.WriteLine($"Positive: {string.Join(", ", positive)}");
Console.WriteLine();

// 9. Anonymous Methods
Console.WriteLine("=== Anonymous Methods ===");
MathOperation subtract = delegate (int x, int y) { return x - y; };
Console.WriteLine($"Subtract(10, 3) = {subtract(10, 3)}");

Action<string> greet = delegate (string name)
{
    Console.WriteLine($"Hello, {name}!");
};
greet("World");
Console.WriteLine();

// Delegate Definitions and Methods in partial class
public partial class Program
{
    public delegate int MathOperation(int x, int y);
    public delegate void NotifyDelegate(string message);

    static int Add(int x, int y) => x + y;
    static int Multiply(int x, int y) => x * y;

    static void NotifyByEmail(string message)
    {
        Console.WriteLine($"Email: {message}");
    }

    static void NotifyBySMS(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }

    static void NotifyByPush(string message)
    {
        Console.WriteLine($"Push Notification: {message}");
    }
}

// Event Example Classes

public class Button
{
    public string Text { get; set; }

    // Event declaration
    public event EventHandler? Clicked;

    public Button(string text)
    {
        Text = text;
    }

    public void Click()
    {
        Console.WriteLine($"Button '{Text}' was clicked!");
        // Raise event
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}

public class TemperatureSensor
{
    private double temperature;

    // Event with custom EventArgs
    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

    public void SetTemperature(double newTemperature)
    {
        double oldTemperature = temperature;
        temperature = newTemperature;
        
        // Raise event with custom arguments
        TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(oldTemperature, newTemperature));
    }
}

public class TemperatureChangedEventArgs : EventArgs
{
    public double OldTemperature { get; }
    public double NewTemperature { get; }

    public TemperatureChangedEventArgs(double oldTemp, double newTemp)
    {
        OldTemperature = oldTemp;
        NewTemperature = newTemp;
    }
}

// Event Handlers
public partial class Program
{
    static void OnButtonClicked(object? sender, EventArgs e)
    {
        Console.WriteLine("Button click handler 1 executed!");
    }

    static void OnButtonClickedAgain(object? sender, EventArgs e)
    {
        Console.WriteLine("Button click handler 2 executed!");
    }

    static void OnTemperatureChanged(object? sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"Temperature changed from {e.OldTemperature}°C to {e.NewTemperature}°C");
    }

    static void OnTemperatureChangedAgain(object? sender, TemperatureChangedEventArgs e)
    {
        double difference = e.NewTemperature - e.OldTemperature;
        Console.WriteLine($"Temperature difference: {difference}°C");
    }
}
