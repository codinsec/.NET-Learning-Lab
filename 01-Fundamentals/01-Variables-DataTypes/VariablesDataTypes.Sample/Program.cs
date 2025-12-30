// Variables & Data Types Examples

// 1. Basic Variable Declarations
int age = 25;
string name = "John";
double salary = 5000.50;
bool isActive = true;
char grade = 'A';

Console.WriteLine("=== Basic Variables ===");
Console.WriteLine($"Name: {name}, Age: {age}, Salary: {salary:C}");
Console.WriteLine($"Active: {isActive}, Grade: {grade}");
Console.WriteLine();

// 2. Using var keyword (Type Inference)
var city = "Istanbul";
var population = 15000000;
var temperature = 15.5;

Console.WriteLine("=== Using var ===");
Console.WriteLine($"City: {city}, Population: {population:N0}, Temperature: {temperature}°C");
Console.WriteLine();

// 3. Nullable Types
int? nullableInt = null;
string? nullableString = null;
bool? nullableBool = null;

Console.WriteLine("=== Nullable Types ===");
Console.WriteLine($"Nullable Int: {nullableInt?.ToString() ?? "null"}");
Console.WriteLine($"Nullable String: {nullableString ?? "null"}");
Console.WriteLine($"Nullable Bool: {nullableBool?.ToString() ?? "null"}");
Console.WriteLine();

// 4. Type Conversions
// Implicit Conversion
int intValue = 100;
long longValue = intValue; // Implicit

// Explicit Conversion (Casting)
double doubleValue = 99.9;
int intFromDouble = (int)doubleValue; // Explicit cast

// Using Convert class
string numberString = "42";
int convertedInt = Convert.ToInt32(numberString);

Console.WriteLine("=== Type Conversions ===");
Console.WriteLine($"Int to Long (Implicit): {longValue}");
Console.WriteLine($"Double to Int (Explicit): {intFromDouble}");
Console.WriteLine($"String to Int (Convert): {convertedInt}");
Console.WriteLine();

// 5. Const and Readonly
const double PI = 3.14159;
const string COMPANY_NAME = "Learning Lab";

DateTime createdDate = DateTime.Now; // readonly can only be used at class level

Console.WriteLine("=== Const & Readonly ===");
Console.WriteLine($"PI: {PI}");
Console.WriteLine($"Company: {COMPANY_NAME}");
Console.WriteLine($"Created: {createdDate:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine();

// 6. Different Numeric Types
byte byteValue = 255;
short shortValue = 32767;
int intValue2 = 2147483647;
long longValue2 = 9223372036854775807L;
float floatValue = 3.14f;
double doubleValue2 = 3.14159265359;
decimal decimalValue = 123.456m;

Console.WriteLine("=== Numeric Types ===");
Console.WriteLine($"Byte: {byteValue}, Short: {shortValue}");
Console.WriteLine($"Int: {intValue2}, Long: {longValue2}");
Console.WriteLine($"Float: {floatValue}, Double: {doubleValue2}, Decimal: {decimalValue}");
Console.WriteLine();

// 7. String Interpolation and Formatting
string firstName = "John";
string lastName = "Smith";
int birthYear = 1990;

string fullInfo = $"{firstName} {lastName}, born in {birthYear}";
Console.WriteLine("=== String Formatting ===");
Console.WriteLine(fullInfo);
Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
