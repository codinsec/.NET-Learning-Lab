// ADO.NET Basics Examples
// Note: These examples demonstrate ADO.NET concepts using simulated data
// In real applications, you would connect to an actual database

using System.Data;
using System.Data.Common;

// 1. Connection String
Console.WriteLine("=== Connection String ===");
string connectionString = "Server=localhost;Database=LearningLab;Trusted_Connection=true;";
Console.WriteLine($"Connection String: {connectionString}");
Console.WriteLine();

// 2. Simulated Connection (for demonstration)
Console.WriteLine("=== Connection Management ===");
Console.WriteLine("In real ADO.NET:");
Console.WriteLine("using (var connection = new SqlConnection(connectionString))");
Console.WriteLine("{");
Console.WriteLine("    connection.Open();");
Console.WriteLine("    // Use connection");
Console.WriteLine("} // Connection automatically closed and disposed");
Console.WriteLine();

// 3. Command Execution
Console.WriteLine("=== Command Execution ===");
Console.WriteLine("ExecuteNonQuery - for INSERT, UPDATE, DELETE");
Console.WriteLine("ExecuteScalar - returns single value");
Console.WriteLine("ExecuteReader - returns DataReader for multiple rows");
Console.WriteLine();

// 4. Parameterized Queries (Conceptual)
Console.WriteLine("=== Parameterized Queries ===");
Console.WriteLine("// Safe way to prevent SQL injection:");
Console.WriteLine("string sql = \"SELECT * FROM Users WHERE Id = @Id\";");
Console.WriteLine("var command = new SqlCommand(sql, connection);");
Console.WriteLine("command.Parameters.AddWithValue(\"@Id\", userId);");
Console.WriteLine();

// 5. DataReader Pattern (Conceptual)
Console.WriteLine("=== DataReader Pattern ===");
Console.WriteLine("using (var reader = command.ExecuteReader())");
Console.WriteLine("{");
Console.WriteLine("    while (reader.Read())");
Console.WriteLine("    {");
Console.WriteLine("        var id = reader.GetInt32(\"Id\");");
Console.WriteLine("        var name = reader.GetString(\"Name\");");
Console.WriteLine("    }");
Console.WriteLine("}");
Console.WriteLine();

// 6. Simulated Data Operations
Console.WriteLine("=== Simulated Data Operations ===");
var dataService = new DataService();

// Simulate SELECT
var users = dataService.GetUsers();
Console.WriteLine("Users:");
foreach (var user in users)
{
    Console.WriteLine($"  ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
}
Console.WriteLine();

// Simulate INSERT
var newUser = dataService.InsertUser("Alice", "alice@example.com");
Console.WriteLine($"Inserted User: ID={newUser.Id}, Name={newUser.Name}");
Console.WriteLine();

// Simulate UPDATE
var updated = dataService.UpdateUser(1, "John Updated", "john.updated@example.com");
Console.WriteLine($"Updated User: {updated}");
Console.WriteLine();

// Simulate DELETE
var deleted = dataService.DeleteUser(2);
Console.WriteLine($"Deleted User: {deleted}");
Console.WriteLine();

// 7. Transaction Pattern (Conceptual)
Console.WriteLine("=== Transaction Pattern ===");
Console.WriteLine("using (var connection = new SqlConnection(connectionString))");
Console.WriteLine("{");
Console.WriteLine("    connection.Open();");
Console.WriteLine("    using (var transaction = connection.BeginTransaction())");
Console.WriteLine("    {");
Console.WriteLine("        try");
Console.WriteLine("        {");
Console.WriteLine("            // Execute multiple commands");
Console.WriteLine("            transaction.Commit();");
Console.WriteLine("        }");
Console.WriteLine("        catch");
Console.WriteLine("        {");
Console.WriteLine("            transaction.Rollback();");
Console.WriteLine("        }");
Console.WriteLine("    }");
Console.WriteLine("}");
Console.WriteLine();

// Helper Classes

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class DataService
{
    private List<User> _users = new List<User>
    {
        new User { Id = 1, Name = "John", Email = "john@example.com" },
        new User { Id = 2, Name = "Jane", Email = "jane@example.com" },
        new User { Id = 3, Name = "Bob", Email = "bob@example.com" }
    };
    private int _nextId = 4;

    public List<User> GetUsers()
    {
        // Simulates: SELECT * FROM Users
        return new List<User>(_users);
    }

    public User? GetUserById(int id)
    {
        // Simulates: SELECT * FROM Users WHERE Id = @Id
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User InsertUser(string name, string email)
    {
        // Simulates: INSERT INTO Users (Name, Email) VALUES (@Name, @Email)
        var user = new User
        {
            Id = _nextId++,
            Name = name,
            Email = email
        };
        _users.Add(user);
        return user;
    }

    public bool UpdateUser(int id, string name, string email)
    {
        // Simulates: UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            user.Name = name;
            user.Email = email;
            return true;
        }
        return false;
    }

    public bool DeleteUser(int id)
    {
        // Simulates: DELETE FROM Users WHERE Id = @Id
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _users.Remove(user);
            return true;
        }
        return false;
    }
}
