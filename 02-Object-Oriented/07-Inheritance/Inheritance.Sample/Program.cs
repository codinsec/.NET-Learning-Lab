// Inheritance Examples

// 1. Basic Inheritance
Console.WriteLine("=== Basic Inheritance ===");
Dog dog = new Dog("Buddy", "Golden Retriever");
dog.MakeSound();
dog.DisplayInfo();
Console.WriteLine();

// 2. Method Overriding
Console.WriteLine("=== Method Overriding ===");
Animal cat = new Cat("Whiskers", "Persian");
cat.MakeSound();
cat.DisplayInfo();
Console.WriteLine();

// 3. Constructor Inheritance
Console.WriteLine("=== Constructor Inheritance ===");
Car car = new Car("Toyota", "Camry", 2023);
car.DisplayInfo();
car.Start();
Console.WriteLine();

// 4. Multiple Levels of Inheritance
Console.WriteLine("=== Multiple Levels ===");
Manager manager = new Manager("John", 50000, "Engineering");
manager.DisplayInfo();
manager.ManageTeam();
Console.WriteLine();

// 5. Using base keyword
Console.WriteLine("=== Using base Keyword ===");
SportsCar sportsCar = new SportsCar("Ferrari", "488", 2024, 330);
sportsCar.DisplayInfo();
sportsCar.Start();
Console.WriteLine();

// 6. Sealed Classes
Console.WriteLine("=== Sealed Classes ===");
FinalClass final = new FinalClass("Cannot be inherited");
final.DisplayMessage();
Console.WriteLine();

// Base Classes

public class Animal
{
    protected string name;

    public Animal(string name)
    {
        this.name = name;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine($"{name} makes a sound");
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Animal: {name}");
    }
}

public class Dog : Animal
{
    private string breed;

    public Dog(string name, string breed) : base(name)
    {
        this.breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} barks: Woof! Woof!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Breed: {breed}");
    }
}

public class Cat : Animal
{
    private string breed;

    public Cat(string name, string breed) : base(name)
    {
        this.breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} meows: Meow! Meow!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Breed: {breed}");
    }
}

public class Vehicle
{
    protected string make;
    protected string model;
    protected int year;

    public Vehicle(string make, string model, int year)
    {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    public virtual void Start()
    {
        Console.WriteLine($"{make} {model} is starting...");
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Vehicle: {year} {make} {model}");
    }
}

public class Car : Vehicle
{
    public Car(string make, string model, int year) : base(make, model, year)
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Engine is running!");
    }
}

public class SportsCar : Car
{
    private int maxSpeed;

    public SportsCar(string make, string model, int year, int maxSpeed) 
        : base(make, model, year)
    {
        this.maxSpeed = maxSpeed;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Max Speed: {maxSpeed} km/h");
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Sports mode activated!");
    }
}

public class Employee
{
    protected string name;
    protected decimal salary;

    public Employee(string name, decimal salary)
    {
        this.name = name;
        this.salary = salary;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Employee: {name}, Salary: ${salary:F2}");
    }

    public virtual void Work()
    {
        Console.WriteLine($"{name} is working...");
    }
}

public class Manager : Employee
{
    private string department;

    public Manager(string name, decimal salary, string department) 
        : base(name, salary)
    {
        this.department = department;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Department: {department}");
    }

    public void ManageTeam()
    {
        Console.WriteLine($"{name} is managing the {department} team");
    }
}

// Sealed class - cannot be inherited
public sealed class FinalClass
{
    private string message;

    public FinalClass(string message)
    {
        this.message = message;
    }

    public void DisplayMessage()
    {
        Console.WriteLine($"Message: {message}");
        Console.WriteLine("This class is sealed and cannot be inherited");
    }
}
