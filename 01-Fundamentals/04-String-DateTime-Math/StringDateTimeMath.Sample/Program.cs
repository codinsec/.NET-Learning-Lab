// String, DateTime & Math Examples
using System.Text;

// 1. String Concatenation
Console.WriteLine("=== String Concatenation ===");
string firstName = "John";
string lastName = "Smith";
string fullName = firstName + " " + lastName;
Console.WriteLine($"Full Name: {fullName}");
Console.WriteLine();

// 2. String Interpolation
Console.WriteLine("=== String Interpolation ===");
int age = 30;
string info = $"Name: {fullName}, Age: {age}";
Console.WriteLine(info);
Console.WriteLine();

// 3. String Methods
Console.WriteLine("=== String Methods ===");
string text = "  Hello World  ";
Console.WriteLine($"Original: '{text}'");
Console.WriteLine($"ToUpper: '{text.ToUpper()}'");
Console.WriteLine($"ToLower: '{text.ToLower()}'");
Console.WriteLine($"Trim: '{text.Trim()}'");
Console.WriteLine($"Length: {text.Length}");
Console.WriteLine($"Substring(2, 5): '{text.Trim().Substring(2, 5)}'");
Console.WriteLine($"Contains('World'): {text.Contains("World")}");
Console.WriteLine($"StartsWith('Hello'): {text.Trim().StartsWith("Hello")}");
Console.WriteLine($"EndsWith('World'): {text.Trim().EndsWith("World")}");
Console.WriteLine();

// 4. String Replace and Split
Console.WriteLine("=== String Replace & Split ===");
string sentence = "The quick brown fox jumps over the lazy dog";
string replaced = sentence.Replace("fox", "cat");
Console.WriteLine($"Original: {sentence}");
Console.WriteLine($"Replaced: {replaced}");

string[] words = sentence.Split(' ');
Console.WriteLine($"Words count: {words.Length}");
Console.WriteLine($"First 3 words: {string.Join(", ", words.Take(3))}");
Console.WriteLine();

// 5. StringBuilder
Console.WriteLine("=== StringBuilder ===");
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" ");
sb.Append("World");
sb.AppendLine("!");
sb.Append("This is a new line.");
Console.WriteLine(sb.ToString());
Console.WriteLine();

// 6. DateTime Basics
Console.WriteLine("=== DateTime Basics ===");
DateTime now = DateTime.Now;
DateTime today = DateTime.Today;
DateTime specificDate = new DateTime(2024, 12, 25, 10, 30, 0);

Console.WriteLine($"Now: {now:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine($"Today: {today:yyyy-MM-dd}");
Console.WriteLine($"Specific: {specificDate:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine();

// 7. DateTime Operations
Console.WriteLine("=== DateTime Operations ===");
DateTime birthDate = new DateTime(1990, 5, 15);
TimeSpan ageSpan = now - birthDate;
int yearsOld = (int)(ageSpan.TotalDays / 365.25);

Console.WriteLine($"Birth Date: {birthDate:yyyy-MM-dd}");
Console.WriteLine($"Age in days: {ageSpan.Days}");
Console.WriteLine($"Age in years: {yearsOld}");
Console.WriteLine();

// 8. DateTime Formatting
Console.WriteLine("=== DateTime Formatting ===");
DateTime date = new DateTime(2024, 12, 30, 14, 30, 45);
Console.WriteLine($"Short Date: {date:d}");
Console.WriteLine($"Long Date: {date:D}");
Console.WriteLine($"Short Time: {date:t}");
Console.WriteLine($"Long Time: {date:T}");
Console.WriteLine($"Custom: {date:dd/MM/yyyy HH:mm}");
Console.WriteLine($"ISO: {date:yyyy-MM-ddTHH:mm:ss}");
Console.WriteLine();

// 9. TimeSpan
Console.WriteLine("=== TimeSpan ===");
TimeSpan duration1 = new TimeSpan(2, 30, 45); // 2 hours, 30 minutes, 45 seconds
TimeSpan duration2 = TimeSpan.FromHours(1.5);
TimeSpan duration3 = duration1 + duration2;

Console.WriteLine($"Duration 1: {duration1}");
Console.WriteLine($"Duration 2: {duration2}");
Console.WriteLine($"Total: {duration3}");
Console.WriteLine($"Total Hours: {duration3.TotalHours:F2}");
Console.WriteLine($"Total Minutes: {duration3.TotalMinutes:F2}");
Console.WriteLine();

// 10. Math Operations
Console.WriteLine("=== Math Operations ===");
double number1 = 25.7;
double number2 = 4.3;

Console.WriteLine($"Math.Abs(-15): {Math.Abs(-15)}");
Console.WriteLine($"Math.Ceiling({number1}): {Math.Ceiling(number1)}");
Console.WriteLine($"Math.Floor({number1}): {Math.Floor(number1)}");
Console.WriteLine($"Math.Round({number1}): {Math.Round(number1)}");
Console.WriteLine($"Math.Max({number1}, {number2}): {Math.Max(number1, number2)}");
Console.WriteLine($"Math.Min({number1}, {number2}): {Math.Min(number1, number2)}");
Console.WriteLine($"Math.Pow(2, 8): {Math.Pow(2, 8)}");
Console.WriteLine($"Math.Sqrt(64): {Math.Sqrt(64)}");
Console.WriteLine($"Math.PI: {Math.PI:F6}");
Console.WriteLine($"Math.E: {Math.E:F6}");
Console.WriteLine();

// 11. String Comparison
Console.WriteLine("=== String Comparison ===");
string str1 = "Hello";
string str2 = "hello";

Console.WriteLine($"str1 == str2: {str1 == str2}");
Console.WriteLine($"str1.Equals(str2): {str1.Equals(str2)}");
Console.WriteLine($"str1.Equals(str2, StringComparison.OrdinalIgnoreCase): {str1.Equals(str2, StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine($"string.Compare(str1, str2): {string.Compare(str1, str2)}");
Console.WriteLine();

// 12. DateTime Parsing
Console.WriteLine("=== DateTime Parsing ===");
string dateString1 = "2024-12-30";
string dateString2 = "30/12/2024 14:30";

if (DateTime.TryParse(dateString1, out DateTime parsedDate1))
{
    Console.WriteLine($"Parsed '{dateString1}': {parsedDate1:yyyy-MM-dd}");
}

if (DateTime.TryParse(dateString2, out DateTime parsedDate2))
{
    Console.WriteLine($"Parsed '{dateString2}': {parsedDate2:yyyy-MM-dd HH:mm}");
}
