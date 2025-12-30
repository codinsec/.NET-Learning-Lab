// Arrays & Collections Examples

// 1. Single-Dimensional Array
Console.WriteLine("=== Single-Dimensional Array ===");
int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
int[] numbers2 = { 10, 20, 30, 40, 50 };

Console.Write("Numbers: ");
foreach (int num in numbers)
{
    Console.Write($"{num} ");
}
Console.WriteLine();
Console.WriteLine($"Array Length: {numbers.Length}");
Console.WriteLine($"First Element: {numbers[0]}, Last Element: {numbers[numbers.Length - 1]}");
Console.WriteLine();

// 2. Multi-Dimensional Array
Console.WriteLine("=== Multi-Dimensional Array ===");
int[,] matrix = new int[3, 3]
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

Console.WriteLine("Matrix:");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"{matrix[i, j],3} ");
    }
    Console.WriteLine();
}
Console.WriteLine();

// 3. Jagged Array
Console.WriteLine("=== Jagged Array ===");
int[][] jagged = new int[3][];
jagged[0] = new int[] { 1, 2, 3 };
jagged[1] = new int[] { 4, 5 };
jagged[2] = new int[] { 6, 7, 8, 9 };

Console.WriteLine("Jagged Array:");
for (int i = 0; i < jagged.Length; i++)
{
    Console.Write($"Row {i}: ");
    foreach (int num in jagged[i])
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();
}
Console.WriteLine();

// 4. List<T>
Console.WriteLine("=== List<T> ===");
List<string> fruits = new List<string> { "Apple", "Banana" };
fruits.Add("Cherry");
fruits.AddRange(new[] { "Date", "Elderberry" });

Console.WriteLine($"Fruits ({fruits.Count}): {string.Join(", ", fruits)}");
Console.WriteLine($"Contains 'Apple': {fruits.Contains("Apple")}");
Console.WriteLine($"Index of 'Cherry': {fruits.IndexOf("Cherry")}");

fruits.Remove("Banana");
Console.WriteLine($"After removing 'Banana': {string.Join(", ", fruits)}");
Console.WriteLine();

// 5. Dictionary<TKey, TValue>
Console.WriteLine("=== Dictionary<TKey, TValue> ===");
Dictionary<string, int> ages = new Dictionary<string, int>
{
    { "John", 25 },
    { "Mike", 30 },
    { "Alex", 28 }
};

ages["Alice"] = 27;

Console.WriteLine("Ages:");
foreach (var kvp in ages)
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
}

Console.WriteLine($"John's age: {ages["John"]}");
Console.WriteLine($"Contains 'Mike': {ages.ContainsKey("Mike")}");
Console.WriteLine();

// 6. HashSet<T>
Console.WriteLine("=== HashSet<T> ===");
HashSet<int> uniqueNumbers = new HashSet<int> { 1, 2, 3, 4, 5 };
uniqueNumbers.Add(3); // Duplicate, won't be added
uniqueNumbers.Add(6);

Console.WriteLine($"Unique Numbers: {string.Join(", ", uniqueNumbers)}");
Console.WriteLine($"Contains 3: {uniqueNumbers.Contains(3)}");
Console.WriteLine($"Count: {uniqueNumbers.Count}");
Console.WriteLine();

// 7. Queue<T>
Console.WriteLine("=== Queue<T> ===");
Queue<string> queue = new Queue<string>();
queue.Enqueue("First");
queue.Enqueue("Second");
queue.Enqueue("Third");

Console.WriteLine("Queue (FIFO):");
while (queue.Count > 0)
{
    Console.WriteLine($"  Dequeued: {queue.Dequeue()}");
}
Console.WriteLine();

// 8. Stack<T>
Console.WriteLine("=== Stack<T> ===");
Stack<string> stack = new Stack<string>();
stack.Push("First");
stack.Push("Second");
stack.Push("Third");

Console.WriteLine("Stack (LIFO):");
while (stack.Count > 0)
{
    Console.WriteLine($"  Popped: {stack.Pop()}");
}
Console.WriteLine();

// 9. Array Methods
Console.WriteLine("=== Array Methods ===");
int[] arr = { 5, 2, 8, 1, 9, 3 };
Console.WriteLine($"Original: {string.Join(", ", arr)}");

Array.Sort(arr);
Console.WriteLine($"Sorted: {string.Join(", ", arr)}");

Array.Reverse(arr);
Console.WriteLine($"Reversed: {string.Join(", ", arr)}");

int index = Array.IndexOf(arr, 8);
Console.WriteLine($"Index of 8: {index}");
Console.WriteLine();

// 10. List Methods
Console.WriteLine("=== List Methods ===");
List<int> numbersList = new List<int> { 5, 2, 8, 1, 9, 3, 2, 5 };
Console.WriteLine($"Original: {string.Join(", ", numbersList)}");

numbersList.Sort();
Console.WriteLine($"Sorted: {string.Join(", ", numbersList)}");

var filtered = numbersList.Where(n => n > 3).ToList();
Console.WriteLine($"Numbers > 3: {string.Join(", ", filtered)}");

var sum = numbersList.Sum();
var average = numbersList.Average();
var max = numbersList.Max();
var min = numbersList.Min();

Console.WriteLine($"Sum: {sum}, Average: {average:F2}, Max: {max}, Min: {min}");
Console.WriteLine();

// 11. LINQ Basics
Console.WriteLine("=== LINQ Basics ===");
List<Person> people = new List<Person>
{
    new Person { Name = "John", Age = 25 },
    new Person { Name = "Mike", Age = 30 },
    new Person { Name = "Alex", Age = 28 },
    new Person { Name = "Alice", Age = 22 }
};

var adults = people.Where(p => p.Age >= 25).ToList();
Console.WriteLine("Adults (Age >= 25):");
foreach (var person in adults)
{
    Console.WriteLine($"  {person.Name} ({person.Age})");
}

var sortedByAge = people.OrderBy(p => p.Age).ToList();
Console.WriteLine("\nSorted by Age:");
foreach (var person in sortedByAge)
{
    Console.WriteLine($"  {person.Name} ({person.Age})");
}

var names = people.Select(p => p.Name).ToList();
Console.WriteLine($"\nNames: {string.Join(", ", names)}");
Console.WriteLine();

// 12. Collection Initialization
Console.WriteLine("=== Collection Initialization ===");
var quickList = new List<int> { 1, 2, 3, 4, 5 };
var quickDict = new Dictionary<string, string>
{
    ["key1"] = "value1",
    ["key2"] = "value2",
    ["key3"] = "value3"
};

Console.WriteLine($"Quick List: {string.Join(", ", quickList)}");
Console.WriteLine("Quick Dictionary:");
foreach (var kvp in quickDict)
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
}

// Helper Class
class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
