// LINQ Queries Examples

List<Person> people = new List<Person>
{
    new Person("John", 30, "Engineering"),
    new Person("Alice", 25, "Marketing"),
    new Person("Bob", 35, "Engineering"),
    new Person("Carol", 28, "Sales"),
    new Person("David", 32, "Engineering"),
    new Person("Eve", 27, "Marketing")
};

List<Product> products = new List<Product>
{
    new Product("Laptop", 999.99m, "Electronics"),
    new Product("Mouse", 29.99m, "Electronics"),
    new Product("Desk", 199.99m, "Furniture"),
    new Product("Chair", 149.99m, "Furniture"),
    new Product("Monitor", 299.99m, "Electronics")
};

// 1. Basic Filtering (Where)
Console.WriteLine("=== Filtering (Where) ===");
var engineers = people.Where(p => p.Department == "Engineering");
Console.WriteLine("Engineers:");
foreach (var person in engineers)
{
    Console.WriteLine($"  {person.Name}, Age: {person.Age}");
}
Console.WriteLine();

// 2. Projection (Select)
Console.WriteLine("=== Projection (Select) ===");
var names = people.Select(p => p.Name);
var ages = people.Select(p => p.Age);
var nameAgePairs = people.Select(p => new { p.Name, p.Age });

Console.WriteLine($"Names: {string.Join(", ", names)}");
Console.WriteLine($"Ages: {string.Join(", ", ages)}");
Console.WriteLine("Name-Age Pairs:");
foreach (var pair in nameAgePairs)
{
    Console.WriteLine($"  {pair.Name}: {pair.Age}");
}
Console.WriteLine();

// 3. Ordering
Console.WriteLine("=== Ordering ===");
var sortedByAge = people.OrderBy(p => p.Age);
var sortedByAgeDesc = people.OrderByDescending(p => p.Age);
var sortedByDeptThenAge = people.OrderBy(p => p.Department).ThenBy(p => p.Age);

Console.WriteLine("Sorted by Age (Ascending):");
foreach (var person in sortedByAge)
{
    Console.WriteLine($"  {person.Name}, Age: {person.Age}");
}
Console.WriteLine("\nSorted by Department, then Age:");
foreach (var person in sortedByDeptThenAge)
{
    Console.WriteLine($"  {person.Name}, {person.Department}, Age: {person.Age}");
}
Console.WriteLine();

// 4. Grouping
Console.WriteLine("=== Grouping ===");
var groupedByDept = people.GroupBy(p => p.Department);
foreach (var group in groupedByDept)
{
    Console.WriteLine($"Department: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($"  {person.Name}, Age: {person.Age}");
    }
}
Console.WriteLine();

// 5. Aggregation
Console.WriteLine("=== Aggregation ===");
var totalAge = people.Sum(p => p.Age);
var averageAge = people.Average(p => p.Age);
var maxAge = people.Max(p => p.Age);
var minAge = people.Min(p => p.Age);
var count = people.Count();
var countEngineers = people.Count(p => p.Department == "Engineering");

Console.WriteLine($"Total Age: {totalAge}");
Console.WriteLine($"Average Age: {averageAge:F2}");
Console.WriteLine($"Max Age: {maxAge}");
Console.WriteLine($"Min Age: {minAge}");
Console.WriteLine($"Total People: {count}");
Console.WriteLine($"Engineers: {countEngineers}");
Console.WriteLine();

// 6. First, Last, Single
Console.WriteLine("=== First, Last, Single ===");
var firstPerson = people.First();
var firstEngineer = people.First(p => p.Department == "Engineering");
var lastPerson = people.Last();
var youngPerson = people.FirstOrDefault(p => p.Age < 20);

Console.WriteLine($"First Person: {firstPerson.Name}");
Console.WriteLine($"First Engineer: {firstEngineer.Name}");
Console.WriteLine($"Last Person: {lastPerson.Name}");
Console.WriteLine($"Young Person (< 20): {(youngPerson != null ? youngPerson.Name : "None")}");
Console.WriteLine();

// 7. Any, All, Contains
Console.WriteLine("=== Any, All, Contains ===");
bool hasEngineers = people.Any(p => p.Department == "Engineering");
bool allAdults = people.All(p => p.Age >= 18);
bool hasJohn = people.Any(p => p.Name == "John");

Console.WriteLine($"Has Engineers: {hasEngineers}");
Console.WriteLine($"All Adults (>= 18): {allAdults}");
Console.WriteLine($"Has John: {hasJohn}");
Console.WriteLine();

// 8. Query Syntax
Console.WriteLine("=== Query Syntax ===");
var querySyntax = from p in people
                 where p.Age > 25
                 orderby p.Age descending
                 select new { p.Name, p.Age };

Console.WriteLine("People over 25 (Query Syntax):");
foreach (var item in querySyntax)
{
    Console.WriteLine($"  {item.Name}, Age: {item.Age}");
}
Console.WriteLine();

// 9. Joining Collections
Console.WriteLine("=== Joining ===");
var joinQuery = from p in people
                join pr in products on p.Department equals pr.Category into productGroup
                select new { Person = p, Products = productGroup };

foreach (var item in joinQuery)
{
    Console.WriteLine($"{item.Person.Name} ({item.Person.Department}):");
    foreach (var product in item.Products)
    {
        Console.WriteLine($"  - {product.Name} (${product.Price:F2})");
    }
}
Console.WriteLine();

// 10. Set Operations
Console.WriteLine("=== Set Operations ===");
List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5 };
List<int> numbers2 = new List<int> { 4, 5, 6, 7, 8 };

var distinct = numbers1.Distinct();
var union = numbers1.Union(numbers2);
var intersect = numbers1.Intersect(numbers2);
var except = numbers1.Except(numbers2);

Console.WriteLine($"Numbers1: {string.Join(", ", numbers1)}");
Console.WriteLine($"Numbers2: {string.Join(", ", numbers2)}");
Console.WriteLine($"Distinct: {string.Join(", ", distinct)}");
Console.WriteLine($"Union: {string.Join(", ", union)}");
Console.WriteLine($"Intersect: {string.Join(", ", intersect)}");
Console.WriteLine($"Except: {string.Join(", ", except)}");
Console.WriteLine();

// 11. Take, Skip, TakeWhile, SkipWhile
Console.WriteLine("=== Take, Skip ===");
var firstThree = people.Take(3);
var skipFirstTwo = people.Skip(2);
var takeWhileYoung = people.TakeWhile(p => p.Age < 30);

Console.WriteLine("First 3 people:");
foreach (var person in firstThree)
{
    Console.WriteLine($"  {person.Name}, Age: {person.Age}");
}
Console.WriteLine("\nSkip first 2:");
foreach (var person in skipFirstTwo)
{
    Console.WriteLine($"  {person.Name}, Age: {person.Age}");
}
Console.WriteLine();

// 12. SelectMany (Flattening)
Console.WriteLine("=== SelectMany ===");
List<List<int>> nestedLists = new List<List<int>>
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5 },
    new List<int> { 6, 7, 8, 9 }
};

var flattened = nestedLists.SelectMany(list => list);
Console.WriteLine($"Flattened: {string.Join(", ", flattened)}");
Console.WriteLine();

// Helper Classes

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Department { get; set; } = string.Empty;

    public Person(string name, int age, string department)
    {
        Name = name;
        Age = age;
        Department = department;
    }
}

public class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;

    public Product(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}
