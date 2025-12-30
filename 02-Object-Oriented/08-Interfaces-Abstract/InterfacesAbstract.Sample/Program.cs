// Interfaces & Abstract Classes Examples

// 1. Basic Interface Implementation
Console.WriteLine("=== Basic Interface ===");
Circle circle = new Circle(5.0);
Rectangle rectangle = new Rectangle(4.0, 6.0);

Console.WriteLine($"Circle Area: {circle.CalculateArea():F2}");
Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea():F2}");
Console.WriteLine();

// 2. Multiple Interface Implementation
Console.WriteLine("=== Multiple Interfaces ===");
SmartPhone phone = new SmartPhone("iPhone 15");
phone.Call("123-456-7890");
phone.SendMessage("Hello!");
phone.TakePhoto();
phone.BrowseInternet();
Console.WriteLine();

// 3. Interface Inheritance
Console.WriteLine("=== Interface Inheritance ===");
Car car = new Car("Toyota", "Camry");
car.Start();
car.Stop();
car.Refuel();
Console.WriteLine();

// 4. Abstract Class
Console.WriteLine("=== Abstract Class ===");
Dog dog = new Dog("Buddy");
Cat cat = new Cat("Whiskers");

dog.MakeSound();
dog.Sleep();
cat.MakeSound();
cat.Sleep();
Console.WriteLine();

// 5. Abstract Methods and Properties
Console.WriteLine("=== Abstract Methods ===");
CircleShape circleShape = new CircleShape(5.0);
RectangleShape rectShape = new RectangleShape(4.0, 6.0);

Console.WriteLine($"Circle - Area: {circleShape.Area:F2}, Perimeter: {circleShape.Perimeter:F2}");
Console.WriteLine($"Rectangle - Area: {rectShape.Area:F2}, Perimeter: {rectShape.Perimeter:F2}");
Console.WriteLine();

// 6. Interface vs Abstract Class
Console.WriteLine("=== Interface vs Abstract Class ===");
DatabaseLogger dbLogger = new DatabaseLogger();
FileLogger fileLogger = new FileLogger();

dbLogger.Log("Database log message");
fileLogger.Log("File log message");
Console.WriteLine();

// Interface Definitions

public interface IShape
{
    double CalculateArea();
}

public interface IDrawable
{
    void Draw();
}

public interface IPhone
{
    void Call(string number);
    void SendMessage(string message);
}

public interface ICamera
{
    void TakePhoto();
}

public interface IInternet
{
    void BrowseInternet();
}

// Interface inheritance
public interface IVehicle
{
    void Start();
    void Stop();
}

public interface IRefuelable : IVehicle
{
    void Refuel();
}

// Class Implementations

public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Rectangle : IShape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double CalculateArea()
    {
        return width * height;
    }
}

// Multiple interface implementation
public class SmartPhone : IPhone, ICamera, IInternet
{
    private string model;

    public SmartPhone(string model)
    {
        this.model = model;
    }

    public void Call(string number)
    {
        Console.WriteLine($"{model} calling {number}");
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{model} sending message: {message}");
    }

    public void TakePhoto()
    {
        Console.WriteLine($"{model} taking a photo");
    }

    public void BrowseInternet()
    {
        Console.WriteLine($"{model} browsing the internet");
    }
}

// Interface inheritance implementation
public class Car : IRefuelable
{
    private string make;
    private string model;

    public Car(string make, string model)
    {
        this.make = make;
        this.model = model;
    }

    public void Start()
    {
        Console.WriteLine($"{make} {model} is starting");
    }

    public void Stop()
    {
        Console.WriteLine($"{make} {model} is stopping");
    }

    public void Refuel()
    {
        Console.WriteLine($"{make} {model} is refueling");
    }
}

// Abstract Class

public abstract class Animal
{
    protected string name;

    public Animal(string name)
    {
        this.name = name;
    }

    // Abstract method - must be implemented by derived classes
    public abstract void MakeSound();

    // Concrete method - already implemented
    public void Sleep()
    {
        Console.WriteLine($"{name} is sleeping");
    }
}

public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} barks: Woof! Woof!");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} meows: Meow! Meow!");
    }
}

// Abstract class with abstract properties

public abstract class Shape
{
    public abstract double Area { get; }
    public abstract double Perimeter { get; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Area: {Area:F2}, Perimeter: {Perimeter:F2}");
    }
}

public class CircleShape : Shape
{
    private double radius;

    public CircleShape(double radius)
    {
        this.radius = radius;
    }

    public override double Area => Math.PI * radius * radius;
    public override double Perimeter => 2 * Math.PI * radius;
}

public class RectangleShape : Shape
{
    private double width;
    private double height;

    public RectangleShape(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area => width * height;
    public override double Perimeter => 2 * (width + height);
}

// Abstract class example - Logger

public abstract class Logger
{
    public abstract void Log(string message);

    protected string FormatMessage(string message)
    {
        return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
    }
}

public class DatabaseLogger : Logger
{
    public override void Log(string message)
    {
        Console.WriteLine($"Database: {FormatMessage(message)}");
    }
}

public class FileLogger : Logger
{
    public override void Log(string message)
    {
        Console.WriteLine($"File: {FormatMessage(message)}");
    }
}
