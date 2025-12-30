// Polymorphism & Encapsulation Examples

// 1. Runtime Polymorphism (Method Overriding)
Console.WriteLine("=== Runtime Polymorphism ===");
Animal[] animals = new Animal[]
{
    new Dog("Buddy"),
    new Cat("Whiskers"),
    new Bird("Tweety")
};

foreach (Animal animal in animals)
{
    animal.MakeSound(); // Polymorphic call
}
Console.WriteLine();

// 2. Compile-time Polymorphism (Method Overloading)
Console.WriteLine("=== Compile-time Polymorphism ===");
Calculator calc = new Calculator();
Console.WriteLine($"Add(5, 3) = {calc.Add(5, 3)}");
Console.WriteLine($"Add(5.5, 3.2) = {calc.Add(5.5, 3.2)}");
Console.WriteLine($"Add(1, 2, 3) = {calc.Add(1, 2, 3)}");
Console.WriteLine();

// 3. Encapsulation with Properties
Console.WriteLine("=== Encapsulation ===");
BankAccount account = new BankAccount("ACC001");
account.Deposit(1000);
Console.WriteLine($"Balance: ${account.Balance:F2}");
account.Withdraw(250);
Console.WriteLine($"Balance: ${account.Balance:F2}");
// account.balance = 10000; // This would be an error - balance is private
Console.WriteLine();

// 4. Encapsulation with Validation
Console.WriteLine("=== Encapsulation with Validation ===");
Person person = new Person();
person.Name = "John";
person.Age = 30;
Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

// Try to set invalid age
person.Age = -5; // Will be rejected
Console.WriteLine($"Age after invalid input: {person.Age}");
Console.WriteLine();

// 5. Access Modifiers
Console.WriteLine("=== Access Modifiers ===");
Employee emp = new Employee("Alice", 50000);
emp.DisplayPublicInfo();
// emp.salary; // Error - salary is private
// emp.department; // Error - department is protected
Console.WriteLine();

// 6. Virtual and Override
Console.WriteLine("=== Virtual and Override ===");
Shape[] shapes = new Shape[]
{
    new Circle(5.0),
    new Rectangle(4.0, 6.0),
    new Triangle(3.0, 4.0, 5.0)
};

foreach (Shape shape in shapes)
{
    Console.WriteLine($"{shape.GetType().Name} - Area: {shape.CalculateArea():F2}");
}
Console.WriteLine();

// 7. Sealed Methods
Console.WriteLine("=== Sealed Methods ===");
BaseClass baseObj = new BaseClass();
DerivedClass derivedObj = new DerivedClass();
FinalClass finalObj = new FinalClass();

baseObj.Display();
derivedObj.Display();
finalObj.Display();
Console.WriteLine();

// Class Definitions

// Polymorphism Example
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
}

public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} barks: Woof! Woof!");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} meows: Meow! Meow!");
    }
}

public class Bird : Animal
{
    public Bird(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} chirps: Tweet! Tweet!");
    }
}

// Method Overloading (Compile-time Polymorphism)
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

// Encapsulation Example
public class BankAccount
{
    private string accountNumber;
    private decimal balance;

    public string AccountNumber => accountNumber;
    public decimal Balance => balance; // Read-only property

    public BankAccount(string accountNumber)
    {
        this.accountNumber = accountNumber;
        balance = 0;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: ${amount:F2}");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: ${amount:F2}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount");
        }
    }
}

// Encapsulation with Validation
public class Person
{
    private string name = string.Empty;
    private int age;

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                name = value;
            }
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value <= 150)
            {
                age = value;
            }
            else
            {
                Console.WriteLine($"Invalid age: {value}. Age must be between 0 and 150.");
            }
        }
    }
}

// Access Modifiers
public class Employee
{
    private decimal salary; // private - only accessible within this class
    protected string department = "General"; // protected - accessible in this class and derived classes
    public string Name { get; set; } = string.Empty; // public - accessible from anywhere

    public Employee(string name, decimal salary)
    {
        Name = name;
        this.salary = salary;
    }

    public void DisplayPublicInfo()
    {
        Console.WriteLine($"Employee: {Name}");
        // Can access private and protected members within the class
        Console.WriteLine($"Salary: ${salary:F2}");
        Console.WriteLine($"Department: {department}");
    }
}

// Virtual and Override
public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return width * height;
    }
}

public class Triangle : Shape
{
    private double a, b, c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double CalculateArea()
    {
        // Heron's formula
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
}

// Sealed Methods
public class BaseClass
{
    public virtual void Display()
    {
        Console.WriteLine("BaseClass Display");
    }
}

public class DerivedClass : BaseClass
{
    public override void Display()
    {
        Console.WriteLine("DerivedClass Display");
    }
}

public class FinalClass : DerivedClass
{
    public sealed override void Display() // Cannot be overridden further
    {
        Console.WriteLine("FinalClass Display (sealed)");
    }
}
