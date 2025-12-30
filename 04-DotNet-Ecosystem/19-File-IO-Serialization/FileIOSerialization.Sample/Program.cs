// File I/O & Serialization Examples
using System.Text.Json;

// 1. Writing and Reading Text Files
Console.WriteLine("=== Writing and Reading Text Files ===");
string filePath = "sample.txt";

// Write to file
File.WriteAllText(filePath, "Hello, File I/O!\nThis is a sample text file.");
Console.WriteLine($"Written to {filePath}");

// Read from file
string content = File.ReadAllText(filePath);
Console.WriteLine($"Content: {content}");
Console.WriteLine();

// 2. Working with Streams
Console.WriteLine("=== Working with Streams ===");
string streamFile = "stream_sample.txt";

using (var writer = new StreamWriter(streamFile))
{
    writer.WriteLine("Line 1");
    writer.WriteLine("Line 2");
    writer.WriteLine("Line 3");
}
Console.WriteLine($"Written to {streamFile} using StreamWriter");

using (var reader = new StreamReader(streamFile))
{
    string? line;
    int lineNumber = 1;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine($"Line {lineNumber}: {line}");
        lineNumber++;
    }
}
Console.WriteLine();

// 3. JSON Serialization
Console.WriteLine("=== JSON Serialization ===");
var person = new Person
{
    Name = "John Doe",
    Age = 30,
    Email = "john@example.com"
};

// Serialize to JSON
string json = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine("Serialized JSON:");
Console.WriteLine(json);

// Save to file
string jsonFile = "person.json";
File.WriteAllText(jsonFile, json);
Console.WriteLine($"Saved to {jsonFile}");
Console.WriteLine();

// 4. JSON Deserialization
Console.WriteLine("=== JSON Deserialization ===");
string jsonFromFile = File.ReadAllText(jsonFile);
var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonFromFile);

if (deserializedPerson != null)
{
    Console.WriteLine($"Deserialized Person:");
    Console.WriteLine($"  Name: {deserializedPerson.Name}");
    Console.WriteLine($"  Age: {deserializedPerson.Age}");
    Console.WriteLine($"  Email: {deserializedPerson.Email}");
}
Console.WriteLine();

// 5. Working with Directories
Console.WriteLine("=== Working with Directories ===");
string dirPath = "TestDirectory";

if (!Directory.Exists(dirPath))
{
    Directory.CreateDirectory(dirPath);
    Console.WriteLine($"Created directory: {dirPath}");
}

string[] files = Directory.GetFiles(dirPath);
Console.WriteLine($"Files in {dirPath}: {files.Length}");

// Create a file in the directory
string fileInDir = Path.Combine(dirPath, "test.txt");
File.WriteAllText(fileInDir, "Test content");
Console.WriteLine($"Created file: {fileInDir}");
Console.WriteLine();

// 6. File and Directory Information
Console.WriteLine("=== File and Directory Information ===");
if (File.Exists(jsonFile))
{
    var fileInfo = new FileInfo(jsonFile);
    Console.WriteLine($"File: {fileInfo.Name}");
    Console.WriteLine($"Full Path: {fileInfo.FullName}");
    Console.WriteLine($"Size: {fileInfo.Length} bytes");
    Console.WriteLine($"Created: {fileInfo.CreationTime}");
    Console.WriteLine($"Modified: {fileInfo.LastWriteTime}");
}
Console.WriteLine();

// 7. Path Operations
Console.WriteLine("=== Path Operations ===");
string fullPath = @"C:\Users\John\Documents\file.txt";
Console.WriteLine($"Full Path: {fullPath}");
Console.WriteLine($"Directory: {Path.GetDirectoryName(fullPath)}");
Console.WriteLine($"FileName: {Path.GetFileName(fullPath)}");
Console.WriteLine($"Extension: {Path.GetExtension(fullPath)}");
Console.WriteLine($"FileName without Extension: {Path.GetFileNameWithoutExtension(fullPath)}");
Console.WriteLine($"Root: {Path.GetPathRoot(fullPath)}");
Console.WriteLine();

// 8. Reading All Lines
Console.WriteLine("=== Reading All Lines ===");
string multiLineFile = "multiline.txt";
File.WriteAllLines(multiLineFile, new[]
{
    "First line",
    "Second line",
    "Third line"
});

string[] lines = File.ReadAllLines(multiLineFile);
Console.WriteLine($"Read {lines.Length} lines:");
foreach (var line in lines)
{
    Console.WriteLine($"  {line}");
}
Console.WriteLine();

// 9. Appending to File
Console.WriteLine("=== Appending to File ===");
string appendFile = "append.txt";
File.WriteAllText(appendFile, "Original content\n");
File.AppendAllText(appendFile, "Appended content\n");
File.AppendAllText(appendFile, "More appended content\n");

Console.WriteLine("File content after appending:");
Console.WriteLine(File.ReadAllText(appendFile));
Console.WriteLine();

// 10. Complex Object Serialization
Console.WriteLine("=== Complex Object Serialization ===");
var company = new Company
{
    Name = "Tech Corp",
    Employees = new List<Person>
    {
        new Person { Name = "Alice", Age = 28, Email = "alice@techcorp.com" },
        new Person { Name = "Bob", Age = 32, Email = "bob@techcorp.com" }
    }
};

string companyJson = JsonSerializer.Serialize(company, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine("Company JSON:");
Console.WriteLine(companyJson);

var deserializedCompany = JsonSerializer.Deserialize<Company>(companyJson);
Console.WriteLine($"\nDeserialized Company: {deserializedCompany?.Name}");
Console.WriteLine($"Employees: {deserializedCompany?.Employees?.Count}");
Console.WriteLine();

// Cleanup
Console.WriteLine("=== Cleanup ===");
File.Delete(filePath);
File.Delete(streamFile);
File.Delete(jsonFile);
File.Delete(multiLineFile);
File.Delete(appendFile);
File.Delete(fileInDir);
Directory.Delete(dirPath);
Console.WriteLine("Temporary files cleaned up");

// Class Definitions

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
}

public class Company
{
    public string Name { get; set; } = string.Empty;
    public List<Person> Employees { get; set; } = new();
}
