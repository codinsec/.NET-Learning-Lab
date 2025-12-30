// Classes & Objects Examples

// 1. Basic Class and Object
Console.WriteLine("=== Basic Class and Object ===");
Person person1 = new Person();
person1.Name = "John";
person1.Age = 30;
person1.DisplayInfo();
Console.WriteLine();

// 2. Constructor with Parameters
Console.WriteLine("=== Constructor with Parameters ===");
Person person2 = new Person("Alice", 25);
person2.DisplayInfo();
Console.WriteLine();

// 3. Properties with Get/Set
Console.WriteLine("=== Properties ===");
BankAccount account = new BankAccount("ACC001");
account.Deposit(1000);
account.Withdraw(250);
Console.WriteLine($"Account Balance: ${account.Balance:F2}");
Console.WriteLine();

// 4. Private Fields and Encapsulation
Console.WriteLine("=== Encapsulation ===");
Student student = new Student("Mike", "CS101");
student.AddGrade(85);
student.AddGrade(92);
student.AddGrade(78);
student.DisplayGrades();
Console.WriteLine($"Average: {student.GetAverage():F2}");
Console.WriteLine();

// 5. Static Members
Console.WriteLine("=== Static Members ===");
Console.WriteLine($"Total Persons Created: {Person.TotalCount}");
Person person3 = new Person("Bob", 28);
Person person4 = new Person("Carol", 32);
Console.WriteLine($"Total Persons Created: {Person.TotalCount}");
Console.WriteLine();

// 6. Object Initialization Syntax
Console.WriteLine("=== Object Initialization ===");
Product product = new Product
{
    Name = "Laptop",
    Price = 999.99m,
    Category = "Electronics"
};
product.DisplayInfo();
Console.WriteLine();

// 7. Multiple Constructors
Console.WriteLine("=== Multiple Constructors ===");
Car car1 = new Car();
Car car2 = new Car("Toyota", "Camry");
Car car3 = new Car("Honda", "Civic", 2023);
car1.DisplayInfo();
car2.DisplayInfo();
car3.DisplayInfo();
Console.WriteLine();

// 8. Read-only Properties
Console.WriteLine("=== Read-only Properties ===");
Circle circle = new Circle(5.0);
Console.WriteLine($"Circle Radius: {circle.Radius}");
Console.WriteLine($"Circle Area: {circle.Area:F2}");
Console.WriteLine($"Circle Circumference: {circle.Circumference:F2}");
Console.WriteLine();

// Class Definitions

public class Person
{
    // Fields
    private string name = string.Empty;
    private int age;

    // Static field
    private static int totalCount = 0;

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    // Static property
    public static int TotalCount => totalCount;

    // Default constructor
    public Person()
    {
        totalCount++;
    }

    // Parameterized constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        totalCount++;
    }

    // Method
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

public class BankAccount
{
    private string accountNumber;
    private decimal balance;

    public string AccountNumber => accountNumber;
    public decimal Balance => balance;

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
            Console.WriteLine("Insufficient funds or invalid amount");
        }
    }
}

public class Student
{
    private string name;
    private string studentId;
    private List<int> grades = new List<int>();

    public string Name => name;
    public string StudentId => studentId;

    public Student(string name, string studentId)
    {
        this.name = name;
        this.studentId = studentId;
    }

    public void AddGrade(int grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            grades.Add(grade);
        }
    }

    public double GetAverage()
    {
        if (grades.Count == 0) return 0;
        return grades.Average();
    }

    public void DisplayGrades()
    {
        Console.WriteLine($"Student: {Name} ({StudentId})");
        Console.WriteLine($"Grades: {string.Join(", ", grades)}");
    }
}

public class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;

    public void DisplayInfo()
    {
        Console.WriteLine($"Product: {Name}, Price: ${Price:F2}, Category: {Category}");
    }
}

public class Car
{
    public string Make { get; set; } = "Unknown";
    public string Model { get; set; } = "Unknown";
    public int Year { get; set; }

    public Car()
    {
    }

    public Car(string make, string model)
    {
        Make = make;
        Model = model;
    }

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public void DisplayInfo()
    {
        if (Year > 0)
        {
            Console.WriteLine($"Car: {Year} {Make} {Model}");
        }
        else
        {
            Console.WriteLine($"Car: {Make} {Model}");
        }
    }
}

public class Circle
{
    private readonly double radius;

    public double Radius => radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Area => Math.PI * radius * radius;
    public double Circumference => 2 * Math.PI * radius;
}
