// Generics Examples

// 1. Generic Class
Console.WriteLine("=== Generic Class ===");
Box<int> intBox = new Box<int>(42);
Box<string> stringBox = new Box<string>("Hello Generics!");

Console.WriteLine($"Int Box: {intBox.GetValue()}");
Console.WriteLine($"String Box: {stringBox.GetValue()}");
Console.WriteLine();

// 2. Generic Method
Console.WriteLine("=== Generic Method ===");
int a = 5, b = 10;
string str1 = "Hello", str2 = "World";

Console.WriteLine($"Swap int: a={a}, b={b}");
Swap(ref a, ref b);
Console.WriteLine($"After swap: a={a}, b={b}");

Console.WriteLine($"Swap string: str1={str1}, str2={str2}");
Swap(ref str1, ref str2);
Console.WriteLine($"After swap: str1={str1}, str2={str2}");
Console.WriteLine();

// 3. Generic with Constraints
Console.WriteLine("=== Generic with Constraints ===");
Calculator<int> intCalc = new Calculator<int>();
Calculator<double> doubleCalc = new Calculator<double>();

Console.WriteLine($"Int Sum: {intCalc.Add(5, 3)}");
Console.WriteLine($"Double Sum: {doubleCalc.Add(5.5, 3.2)}");
Console.WriteLine();

// 4. Generic Repository Pattern
Console.WriteLine("=== Generic Repository ===");
Repository<Person> personRepo = new Repository<Person>();
personRepo.Add(new Person("John", 30));
personRepo.Add(new Person("Alice", 25));
personRepo.Add(new Person("Bob", 35));

var allPeople = personRepo.GetAll();
Console.WriteLine("All People:");
foreach (var person in allPeople)
{
    Console.WriteLine($"  {person.Name}, Age: {person.Age}");
}

var foundPerson = personRepo.GetById(1);
Console.WriteLine($"\nPerson with ID 1: {foundPerson?.Name}");
Console.WriteLine();

// 5. Generic Collections
Console.WriteLine("=== Generic Collections ===");
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Dictionary<string, int> ages = new Dictionary<string, int>
{
    { "John", 30 },
    { "Alice", 25 },
    { "Bob", 35 }
};

Console.WriteLine("Numbers:");
foreach (var num in numbers)
{
    Console.Write($"{num} ");
}
Console.WriteLine("\n\nAges:");
foreach (var kvp in ages)
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
}
Console.WriteLine();

// 6. Generic Interface
Console.WriteLine("=== Generic Interface ===");
Cache<string> stringCache = new Cache<string>();
stringCache.Store("key1", "value1");
stringCache.Store("key2", "value2");

Console.WriteLine($"Cache[key1]: {stringCache.Retrieve("key1")}");
Console.WriteLine($"Cache[key2]: {stringCache.Retrieve("key2")}");
Console.WriteLine();

// 7. Multiple Type Parameters
Console.WriteLine("=== Multiple Type Parameters ===");
Pair<string, int> pair = new Pair<string, int>("Age", 30);
Console.WriteLine($"Pair: {pair.First} = {pair.Second}");

Triple<int, string, bool> triple = new Triple<int, string, bool>(1, "Active", true);
Console.WriteLine($"Triple: {triple.First}, {triple.Second}, {triple.Third}");
Console.WriteLine();

// 8. Generic with Default
Console.WriteLine("=== Generic with Default ===");
Utility<int> intUtility = new Utility<int>();
Utility<string> stringUtility = new Utility<string>();

Console.WriteLine($"Default int: {intUtility.GetDefault()}");
Console.WriteLine($"Default string: {stringUtility.GetDefault() ?? "null"}");
Console.WriteLine();

// Generic Class Definitions

public partial class Program
{
}

public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public T GetValue()
    {
        return value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }
}

// Generic Method
public static class Helper
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

// Swap method in partial class
public partial class Program
{
    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

// Generic with Constraints
public class Calculator<T> where T : struct, IComparable<T>
{
    public T Add(T a, T b)
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)((int)(object)a + (int)(object)b);
        }
        else if (typeof(T) == typeof(double))
        {
            return (T)(object)((double)(object)a + (double)(object)b);
        }
        throw new NotSupportedException($"Type {typeof(T)} not supported");
    }
}

// Generic Repository
public class Repository<T> where T : class
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public T? GetById(int id)
    {
        if (id > 0 && id <= items.Count)
        {
            return items[id - 1];
        }
        return default(T);
    }

    public List<T> GetAll()
    {
        return new List<T>(items);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }
}

// Generic Interface
public interface ICache<T>
{
    void Store(string key, T value);
    T? Retrieve(string key);
}

public class Cache<T> : ICache<T>
{
    private Dictionary<string, T> storage = new Dictionary<string, T>();

    public void Store(string key, T value)
    {
        storage[key] = value;
    }

    public T? Retrieve(string key)
    {
        return storage.TryGetValue(key, out T? value) ? value : default(T);
    }
}

// Multiple Type Parameters
public class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }
}

public class Triple<TFirst, TSecond, TThird>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }
    public TThird Third { get; set; }

    public Triple(TFirst first, TSecond second, TThird third)
    {
        First = first;
        Second = second;
        Third = third;
    }
}

// Generic with Default
public class Utility<T>
{
    public T? GetDefault()
    {
        return default(T);
    }
}

// Helper Classes
public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
