// Structs, Enums & Records Examples

// 1. Structs (Value Types)
Console.WriteLine("=== Structs ===");
Point point1 = new Point(10, 20);
Point point2 = point1; // Copy, not reference
point2.X = 30;

Console.WriteLine($"Point1: ({point1.X}, {point1.Y})");
Console.WriteLine($"Point2: ({point2.X}, {point2.Y})");
Console.WriteLine($"Are equal: {point1.Equals(point2)}");
Console.WriteLine();

// 2. Enums
Console.WriteLine("=== Enums ===");
DayOfWeek today = DayOfWeek.Monday;
Console.WriteLine($"Today is: {today}");
Console.WriteLine($"Numeric value: {(int)today}");

Status currentStatus = Status.Active;
Console.WriteLine($"Status: {currentStatus}");
Console.WriteLine();

// 3. Enum with Switch Expression
Console.WriteLine("=== Enum Switch Expression ===");
Console.WriteLine($"Priority {Priority.High} message: {PriorityHelper.GetPriorityMessage(Priority.High)}");
Console.WriteLine($"Priority {Priority.Low} message: {PriorityHelper.GetPriorityMessage(Priority.Low)}");
Console.WriteLine();

// 4. Enum Flags
Console.WriteLine("=== Enum Flags ===");
Permissions userPermissions = Permissions.Read | Permissions.Write;
Console.WriteLine($"User Permissions: {userPermissions}");

if ((userPermissions & Permissions.Read) == Permissions.Read)
{
    Console.WriteLine("User has Read permission");
}

Permissions adminPermissions = Permissions.Read | Permissions.Write | Permissions.Delete | Permissions.Execute;
Console.WriteLine($"Admin Permissions: {adminPermissions}");
Console.WriteLine();

// 5. Records (C# 9.0+)
Console.WriteLine("=== Records ===");
Person person1 = new Person("John", "Doe", 30);
Person person2 = new Person("John", "Doe", 30);
Person person3 = new Person("Jane", "Smith", 25);

Console.WriteLine($"Person1: {person1}");
Console.WriteLine($"Person2: {person2}");
Console.WriteLine($"Person1 == Person2: {person1 == person2}"); // Value equality
Console.WriteLine($"Person1 == Person3: {person1 == person3}");
Console.WriteLine();

// 6. Records with Expression
Console.WriteLine("=== Records with Expression ===");
Person updatedPerson = person1 with { Age = 31 };
Console.WriteLine($"Original: {person1}");
Console.WriteLine($"Updated: {updatedPerson}");
Console.WriteLine();

// 7. Positional Records
Console.WriteLine("=== Positional Records ===");
PointRecord pointRecord1 = new PointRecord(10, 20);
PointRecord pointRecord2 = new PointRecord(10, 20);
PointRecord pointRecord3 = new PointRecord(30, 40);

Console.WriteLine($"PointRecord1: {pointRecord1}");
Console.WriteLine($"PointRecord2: {pointRecord2}");
Console.WriteLine($"PointRecord1 == PointRecord2: {pointRecord1 == pointRecord2}");
Console.WriteLine($"PointRecord1 == PointRecord3: {pointRecord1 == pointRecord3}");

var (x, y) = pointRecord1; // Deconstruction
Console.WriteLine($"Deconstructed: X={x}, Y={y}");
Console.WriteLine();

// 8. Record with Methods
Console.WriteLine("=== Record with Methods ===");
Product product = new Product("Laptop", 999.99m);
Console.WriteLine($"Product: {product}");
Console.WriteLine($"Discounted Price (10%): ${product.GetDiscountedPrice(0.10m):F2}");
Console.WriteLine();

// 9. Struct vs Class Comparison
Console.WriteLine("=== Struct vs Class ===");
StructExample struct1 = new StructExample { Value = 10 };
StructExample struct2 = struct1; // Copy
struct2.Value = 20;

ClassExample class1 = new ClassExample { Value = 10 };
ClassExample class2 = class1; // Reference
class2.Value = 20;

Console.WriteLine($"Struct1.Value: {struct1.Value}"); // Still 10
Console.WriteLine($"Struct2.Value: {struct2.Value}"); // 20
Console.WriteLine($"Class1.Value: {class1.Value}"); // 20 (changed!)
Console.WriteLine($"Class2.Value: {class2.Value}"); // 20
Console.WriteLine();

// Definitions

// Struct
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}

// Enum
public enum DayOfWeek
{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7
}

public enum Status
{
    Inactive,
    Active,
    Pending,
    Suspended
}

public enum Priority
{
    Low,
    Medium,
    High,
    Critical
}

// Enum Flags
[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    Execute = 8
}

// Record
public record Person(string FirstName, string LastName, int Age);

// Positional Record
public record PointRecord(int X, int Y);

// Record with Methods
public record Product(string Name, decimal Price)
{
    public decimal GetDiscountedPrice(decimal discountPercentage)
    {
        return Price * (1 - discountPercentage);
    }
}

// Struct vs Class
public struct StructExample
{
    public int Value { get; set; }
}

public class ClassExample
{
    public int Value { get; set; }
}

// Helper Class
public static class PriorityHelper
{
    public static string GetPriorityMessage(Priority priority) => priority switch
    {
        Priority.Low => "This can be handled later",
        Priority.Medium => "This should be addressed soon",
        Priority.High => "This needs immediate attention",
        Priority.Critical => "This is urgent!",
        _ => "Unknown priority"
    };
}
