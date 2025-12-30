// Methods & Functions Examples

// 1. Basic Method
Console.WriteLine("=== Basic Method ===");
int result = Program.Add(5, 3);
Console.WriteLine($"5 + 3 = {result}");
Console.WriteLine();

// 2. Method with Return Type
Console.WriteLine("=== Method with Return ===");
string greeting = Program.GetGreeting("John");
Console.WriteLine(greeting);
Console.WriteLine();

// 3. Void Method
Console.WriteLine("=== Void Method ===");
Program.PrintMessage("Hello from void method!");
Console.WriteLine();

// 4. Method Overloading
Console.WriteLine("=== Method Overloading ===");
Console.WriteLine($"Add(5, 3) = {Program.Add(5, 3)}");
Console.WriteLine($"Add(5.5, 3.2) = {Program.Add(5.5, 3.2)}");
Console.WriteLine($"Add(5, 3, 2) = {Program.Add(5, 3, 2)}");
Console.WriteLine();

// 5. Optional Parameters
Console.WriteLine("=== Optional Parameters ===");
Console.WriteLine($"Greet() = {Program.Greet()}");
Console.WriteLine($"Greet(\"Mike\") = {Program.Greet("Mike")}");
Console.WriteLine($"Greet(\"Alex\", \"Good evening\") = {Program.Greet("Alex", "Good evening")}");
Console.WriteLine();

// 6. Ref Parameter
Console.WriteLine("=== Ref Parameter ===");
int number = 10;
Console.WriteLine($"Before: number = {number}");
Program.IncrementByRef(ref number);
Console.WriteLine($"After: number = {number}");
Console.WriteLine();

// 7. Out Parameter
Console.WriteLine("=== Out Parameter ===");
if (Program.TryDivide(10, 2, out double quotient))
{
    Console.WriteLine($"10 / 2 = {quotient}");
}
else
{
    Console.WriteLine("Division failed!");
}

if (Program.TryDivide(10, 0, out double quotient2))
{
    Console.WriteLine($"10 / 0 = {quotient2}");
}
else
{
    Console.WriteLine("Division by zero!");
}
Console.WriteLine();

// 8. Params Parameter
Console.WriteLine("=== Params Parameter ===");
int sum1 = Program.SumNumbers(1, 2, 3);
int sum2 = Program.SumNumbers(10, 20, 30, 40, 50);
Console.WriteLine($"Sum(1,2,3) = {sum1}");
Console.WriteLine($"Sum(10,20,30,40,50) = {sum2}");
Console.WriteLine();

// 9. Expression-Bodied Method
Console.WriteLine("=== Expression-Bodied Method ===");
int square = Program.Square(5);
Console.WriteLine($"Square(5) = {square}");
Console.WriteLine();

// 10. Local Function
Console.WriteLine("=== Local Function ===");
int factorial = Program.CalculateFactorial(5);
Console.WriteLine($"Factorial(5) = {factorial}");
Console.WriteLine();

// 11. Method with Multiple Return Types
Console.WriteLine("=== Multiple Return Types ===");
var (min, max) = Program.FindMinMax(5, 2, 8, 1, 9);
Console.WriteLine($"Min: {min}, Max: {max}");
Console.WriteLine();

// Method Definitions
public partial class Program
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public static string GetGreeting(string name)
    {
        return $"Hello, {name}!";
    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static string Greet(string name = "Guest", string greeting = "Hello")
    {
        return $"{greeting}, {name}!";
    }

    public static void IncrementByRef(ref int value)
    {
        value++;
    }

    public static bool TryDivide(double dividend, double divisor, out double result)
    {
        if (divisor == 0)
        {
            result = 0;
            return false;
        }
        result = dividend / divisor;
        return true;
    }

    public static int SumNumbers(params int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    public static int Square(int x) => x * x;

    public static int CalculateFactorial(int n)
    {
        if (n <= 1) return 1;
        
        int Factorial(int num)
        {
            if (num <= 1) return 1;
            return num * Factorial(num - 1);
        }
        
        return Factorial(n);
    }

    public static (int min, int max) FindMinMax(params int[] numbers)
    {
        if (numbers.Length == 0)
            return (0, 0);
        
        int min = numbers[0];
        int max = numbers[0];
        
        foreach (int num in numbers)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }
        
        return (min, max);
    }
}
