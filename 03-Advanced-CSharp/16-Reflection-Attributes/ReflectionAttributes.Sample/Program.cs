// Reflection & Attributes Examples
using System.Reflection;

// 1. Getting Type Information
Console.WriteLine("=== Getting Type Information ===");
Type stringType = typeof(string);
Type intType = typeof(int);
Type personType = typeof(Person);

Console.WriteLine($"String Type: {stringType.Name}");
Console.WriteLine($"String Full Name: {stringType.FullName}");
Console.WriteLine($"String Namespace: {stringType.Namespace}");
Console.WriteLine($"Is String a Class: {stringType.IsClass}");
Console.WriteLine($"Is Int a Value Type: {intType.IsValueType}");
Console.WriteLine();

// 2. Getting Properties
Console.WriteLine("=== Getting Properties ===");
PropertyInfo[] properties = personType.GetProperties();
Console.WriteLine($"Person Properties ({properties.Length}):");
foreach (var prop in properties)
{
    Console.WriteLine($"  {prop.Name} ({prop.PropertyType.Name})");
}
Console.WriteLine();

// 3. Getting Methods
Console.WriteLine("=== Getting Methods ===");
MethodInfo[] methods = personType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
Console.WriteLine($"Person Methods ({methods.Length}):");
foreach (var method in methods)
{
    Console.WriteLine($"  {method.Name}()");
}
Console.WriteLine();

// 4. Creating Instance Dynamically
Console.WriteLine("=== Creating Instance Dynamically ===");
object? personInstance = Activator.CreateInstance(personType, "John", 30);
if (personInstance is Person person)
{
    Console.WriteLine($"Created Person: {person.Name}, Age: {person.Age}");
}
Console.WriteLine();

// 5. Setting Property Value
Console.WriteLine("=== Setting Property Value ===");
PropertyInfo? nameProperty = personType.GetProperty("Name");
if (nameProperty != null && personInstance != null)
{
    nameProperty.SetValue(personInstance, "Alice");
    Console.WriteLine($"Updated Name: {nameProperty.GetValue(personInstance)}");
}
Console.WriteLine();

// 6. Invoking Methods
Console.WriteLine("=== Invoking Methods ===");
MethodInfo? displayMethod = personType.GetMethod("DisplayInfo");
if (displayMethod != null && personInstance != null)
{
    displayMethod.Invoke(personInstance, null);
}
Console.WriteLine();

// 7. Custom Attributes
Console.WriteLine("=== Custom Attributes ===");
var authorAttribute = typeof(Book).GetCustomAttribute<AuthorAttribute>();
if (authorAttribute != null)
{
    Console.WriteLine($"Book Author: {authorAttribute.Name}");
    Console.WriteLine($"Author Email: {authorAttribute.Email}");
}

var versionAttribute = typeof(Book).GetCustomAttribute<VersionAttribute>();
if (versionAttribute != null)
{
    Console.WriteLine($"Book Version: {versionAttribute.Major}.{versionAttribute.Minor}");
}
Console.WriteLine();

// 8. Reading Attributes from Properties
Console.WriteLine("=== Reading Attributes from Properties ===");
PropertyInfo[] bookProperties = typeof(Book).GetProperties();
foreach (var prop in bookProperties)
{
    var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
    if (requiredAttr != null)
    {
        Console.WriteLine($"{prop.Name} is required");
    }
}
Console.WriteLine();

// 9. Getting All Attributes
Console.WriteLine("=== Getting All Attributes ===");
object[] attributes = typeof(Book).GetCustomAttributes(true);
Console.WriteLine($"Book has {attributes.Length} attributes:");
foreach (var attr in attributes)
{
    Console.WriteLine($"  {attr.GetType().Name}");
}
Console.WriteLine();

// 10. Checking if Type Has Attribute
Console.WriteLine("=== Checking for Attributes ===");
bool hasAuthor = typeof(Book).IsDefined(typeof(AuthorAttribute), false);
bool hasVersion = typeof(Book).IsDefined(typeof(VersionAttribute), false);

Console.WriteLine($"Book has AuthorAttribute: {hasAuthor}");
Console.WriteLine($"Book has VersionAttribute: {hasVersion}");
Console.WriteLine();

// Class Definitions

[Author("John Doe", "john@example.com")]
[Version(1, 0)]
public class Book
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    public int Pages { get; set; }
}

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Person: {Name}, Age: {Age}");
    }
}

// Custom Attributes

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class AuthorAttribute : Attribute
{
    public string Name { get; }
    public string Email { get; }

    public AuthorAttribute(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute : Attribute
{
    public int Major { get; }
    public int Minor { get; }

    public VersionAttribute(int major, int minor)
    {
        Major = major;
        Minor = minor;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class RequiredAttribute : Attribute
{
}
