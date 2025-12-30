// Dapper & Mini ORM Examples
// Note: These examples demonstrate Dapper concepts using simulated data
// In real applications, you would use actual database connections

using Dapper;

Console.WriteLine("=== Dapper & Mini ORM ===");
Console.WriteLine();

// 1. Dapper Basics
Console.WriteLine("=== Dapper Basics ===");
Console.WriteLine("Dapper extends IDbConnection with methods:");
Console.WriteLine("  - Query<T>: Returns IEnumerable<T>");
Console.WriteLine("  - QueryFirst<T>: Returns first result");
Console.WriteLine("  - QuerySingle<T>: Returns single result");
Console.WriteLine("  - Execute: Executes command, returns rows affected");
Console.WriteLine();

// 2. Query Example (Conceptual)
Console.WriteLine("=== Query Example ===");
Console.WriteLine("// Real Dapper usage:");
Console.WriteLine("using (var connection = new SqlConnection(connectionString))");
Console.WriteLine("{");
Console.WriteLine("    var users = connection.Query<User>(\"SELECT * FROM Users\");");
Console.WriteLine("    foreach (var user in users)");
Console.WriteLine("    {");
Console.WriteLine("        Console.WriteLine(user.Name);");
Console.WriteLine("    }");
Console.WriteLine("}");
Console.WriteLine();

// 3. Parameterized Queries (Conceptual)
Console.WriteLine("=== Parameterized Queries ===");
Console.WriteLine("var sql = \"SELECT * FROM Users WHERE Id = @Id\";");
Console.WriteLine("var user = connection.QueryFirstOrDefault<User>(sql, new { Id = 1 });");
Console.WriteLine();
Console.WriteLine("Multiple parameters:");
Console.WriteLine("var sql = \"SELECT * FROM Users WHERE Age > @MinAge AND City = @City\";");
Console.WriteLine("var users = connection.Query<User>(sql, new { MinAge = 18, City = \"New York\" });");
Console.WriteLine();

// 4. Simulated Dapper Operations
Console.WriteLine("=== Simulated Dapper Operations ===");
var dapperService = new DapperService();

// Simulate Query
var allUsers = dapperService.Query<User>("SELECT * FROM Users");
Console.WriteLine("All Users:");
foreach (var user in allUsers)
{
    Console.WriteLine($"  {user.Id}: {user.Name}, {user.Email}");
}
Console.WriteLine();

// Simulate QueryFirst
var foundUser = dapperService.QueryFirst<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = 1 });
Console.WriteLine($"User with ID 1: {foundUser.Name}");
Console.WriteLine();

// Simulate Execute
var rowsAffected = dapperService.Execute(
    "UPDATE Users SET Email = @Email WHERE Id = @Id",
    new { Id = 1, Email = "newemail@example.com" }
);
Console.WriteLine($"Rows affected: {rowsAffected}");
Console.WriteLine();

// 5. Multiple Result Sets (Conceptual)
Console.WriteLine("=== Multiple Result Sets ===");
Console.WriteLine("using (var multi = connection.QueryMultiple(sql))");
Console.WriteLine("{");
Console.WriteLine("    var users = multi.Read<User>().ToList();");
Console.WriteLine("    var orders = multi.Read<Order>().ToList();");
Console.WriteLine("}");
Console.WriteLine();

// 6. Stored Procedures (Conceptual)
Console.WriteLine("=== Stored Procedures ===");
Console.WriteLine("var users = connection.Query<User>(");
Console.WriteLine("    \"GetUsersByCity\",");
Console.WriteLine("    new { City = \"New York\" },");
Console.WriteLine("    commandType: CommandType.StoredProcedure");
Console.WriteLine(");");
Console.WriteLine();

// 7. Transactions (Conceptual)
Console.WriteLine("=== Transactions ===");
Console.WriteLine("using (var connection = new SqlConnection(connectionString))");
Console.WriteLine("{");
Console.WriteLine("    connection.Open();");
Console.WriteLine("    using (var transaction = connection.BeginTransaction())");
Console.WriteLine("    {");
Console.WriteLine("        try");
Console.WriteLine("        {");
Console.WriteLine("            connection.Execute(sql1, param1, transaction);");
Console.WriteLine("            connection.Execute(sql2, param2, transaction);");
Console.WriteLine("            transaction.Commit();");
Console.WriteLine("        }");
Console.WriteLine("        catch");
Console.WriteLine("        {");
Console.WriteLine("            transaction.Rollback();");
Console.WriteLine("        }");
Console.WriteLine("    }");
Console.WriteLine("}");
Console.WriteLine();

// 8. Dapper vs EF Core
Console.WriteLine("=== Dapper vs EF Core ===");
Console.WriteLine("Dapper Advantages:");
Console.WriteLine("  - Faster performance");
Console.WriteLine("  - Lower memory usage");
Console.WriteLine("  - Full SQL control");
Console.WriteLine("  - Simple and lightweight");
Console.WriteLine();
Console.WriteLine("EF Core Advantages:");
Console.WriteLine("  - Change tracking");
Console.WriteLine("  - LINQ queries");
Console.WriteLine("  - Migrations");
Console.WriteLine("  - Rich feature set");
Console.WriteLine();
Console.WriteLine("Choose Dapper when:");
Console.WriteLine("  - Performance is critical");
Console.WriteLine("  - You need full SQL control");
Console.WriteLine("  - Simple CRUD operations");
Console.WriteLine();
Console.WriteLine("Choose EF Core when:");
Console.WriteLine("  - Complex domain models");
Console.WriteLine("  - You need change tracking");
Console.WriteLine("  - You want LINQ queries");
Console.WriteLine();

// Helper Classes

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
}

public class DapperService
{
    private List<User> _users = new List<User>
    {
        new User { Id = 1, Name = "John", Email = "john@example.com", Age = 30 },
        new User { Id = 2, Name = "Alice", Email = "alice@example.com", Age = 25 },
        new User { Id = 3, Name = "Bob", Email = "bob@example.com", Age = 35 }
    };

    // Simulates Dapper Query
    public IEnumerable<T> Query<T>(string sql, object? param = null) where T : class
    {
        // In real Dapper, this would execute SQL and map results
        // For demo, we return simulated data
        if (typeof(T) == typeof(User))
        {
            return (IEnumerable<T>)_users;
        }
        return Enumerable.Empty<T>();
    }

    // Simulates Dapper QueryFirst
    public T QueryFirst<T>(string sql, object? param = null) where T : class
    {
        if (typeof(T) == typeof(User) && param != null)
        {
            var idProperty = param.GetType().GetProperty("Id");
            if (idProperty != null)
            {
                var id = (int)idProperty.GetValue(param)!;
                var user = _users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    return (T)(object)user;
                }
            }
        }
        return (T)(object)_users.First();
    }

    // Simulates Dapper Execute
    public int Execute(string sql, object? param = null)
    {
        // In real Dapper, this would execute SQL and return rows affected
        if (param != null)
        {
            var idProperty = param.GetType().GetProperty("Id");
            var emailProperty = param.GetType().GetProperty("Email");
            if (idProperty != null && emailProperty != null)
            {
                var id = (int)idProperty.GetValue(param)!;
                var email = emailProperty.GetValue(param)?.ToString();
                var user = _users.FirstOrDefault(u => u.Id == id);
                if (user != null && email != null)
                {
                    user.Email = email;
                    return 1; // Rows affected
                }
            }
        }
        return 0;
    }
}
