// Conditionals & Loops Examples

// 1. If-Else Statements
Console.WriteLine("=== If-Else Statements ===");
int score = 85;

if (score >= 90)
{
    Console.WriteLine("Grade: A");
}
else if (score >= 80)
{
    Console.WriteLine("Grade: B");
}
else if (score >= 70)
{
    Console.WriteLine("Grade: C");
}
else
{
    Console.WriteLine("Grade: F");
}
Console.WriteLine();

// 2. Switch Statement
Console.WriteLine("=== Switch Statement ===");
string dayOfWeek = "Monday";

switch (dayOfWeek)
{
    case "Monday":
    case "Tuesday":
    case "Wednesday":
    case "Thursday":
    case "Friday":
        Console.WriteLine("Weekday");
        break;
    case "Saturday":
    case "Sunday":
        Console.WriteLine("Weekend");
        break;
    default:
        Console.WriteLine("Invalid day");
        break;
}
Console.WriteLine();

// 3. Switch Expression (C# 8.0+)
Console.WriteLine("=== Switch Expression ===");
int month = 3;
string season = month switch
{
    12 or 1 or 2 => "Winter",
    3 or 4 or 5 => "Spring",
    6 or 7 or 8 => "Summer",
    9 or 10 or 11 => "Fall",
    _ => "Invalid month"
};
Console.WriteLine($"Month {month} is in {season}");
Console.WriteLine();

// 4. Ternary Operator
Console.WriteLine("=== Ternary Operator ===");
int age = 20;
string status = age >= 18 ? "Adult" : "Minor";
Console.WriteLine($"Age {age}: {status}");
Console.WriteLine();

// 5. For Loop
Console.WriteLine("=== For Loop ===");
Console.Write("Counting 1 to 5: ");
for (int i = 1; i <= 5; i++)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
Console.WriteLine();

// 6. While Loop
Console.WriteLine("=== While Loop ===");
int counter = 0;
Console.Write("Counting 0 to 4: ");
while (counter < 5)
{
    Console.Write($"{counter} ");
    counter++;
}
Console.WriteLine();
Console.WriteLine();

// 7. Do-While Loop
Console.WriteLine("=== Do-While Loop ===");
int number = 0;
Console.Write("Counting 0 to 4: ");
do
{
    Console.Write($"{number} ");
    number++;
} while (number < 5);
Console.WriteLine();
Console.WriteLine();

// 8. Foreach Loop
Console.WriteLine("=== Foreach Loop ===");
string[] fruits = { "Apple", "Banana", "Cherry", "Date" };
Console.Write("Fruits: ");
foreach (string fruit in fruits)
{
    Console.Write($"{fruit} ");
}
Console.WriteLine();
Console.WriteLine();

// 9. Break and Continue
Console.WriteLine("=== Break & Continue ===");
Console.Write("Numbers 1-10 (skip 5, stop at 8): ");
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
        continue; // Skip 5
    if (i == 8)
        break; // Stop at 8
    
    Console.Write($"{i} ");
}
Console.WriteLine();
Console.WriteLine();

// 10. Nested Loops
Console.WriteLine("=== Nested Loops ===");
Console.WriteLine("Multiplication Table (1-3):");
for (int i = 1; i <= 3; i++)
{
    for (int j = 1; j <= 3; j++)
    {
        Console.Write($"{i * j,3} ");
    }
    Console.WriteLine();
}
Console.WriteLine();

// 11. Complex Conditional Example
Console.WriteLine("=== Complex Conditional ===");
int temperature = 25;
bool isRaining = false;
bool hasUmbrella = true;

if (temperature > 20 && !isRaining)
{
    Console.WriteLine("Perfect weather for a walk!");
}
else if (isRaining && hasUmbrella)
{
    Console.WriteLine("You can go out with an umbrella.");
}
else if (isRaining && !hasUmbrella)
{
    Console.WriteLine("Stay indoors!");
}
else
{
    Console.WriteLine("Weather is okay.");
}
