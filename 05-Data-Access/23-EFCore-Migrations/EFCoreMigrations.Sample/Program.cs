// EF Core Migrations Examples
using Microsoft.EntityFrameworkCore;

// Note: This example demonstrates migration concepts
// In a real project, you would use Package Manager Console or CLI commands:
// 
// Package Manager Console:
//   Add-Migration InitialCreate
//   Update-Database
//
// CLI:
//   dotnet ef migrations add InitialCreate
//   dotnet ef database update

Console.WriteLine("=== EF Core Migrations ===");
Console.WriteLine();

// 1. Migration Concepts
Console.WriteLine("=== Migration Concepts ===");
Console.WriteLine("Migrations allow you to:");
Console.WriteLine("  - Track database schema changes");
Console.WriteLine("  - Apply changes incrementally");
Console.WriteLine("  - Rollback changes if needed");
Console.WriteLine("  - Keep database in sync with code");
Console.WriteLine();

// 2. Creating Migrations
Console.WriteLine("=== Creating Migrations ===");
Console.WriteLine("Commands to create migration:");
Console.WriteLine("  Package Manager: Add-Migration MigrationName");
Console.WriteLine("  CLI: dotnet ef migrations add MigrationName");
Console.WriteLine();
Console.WriteLine("Example:");
Console.WriteLine("  Add-Migration InitialCreate");
Console.WriteLine("  Add-Migration AddEmailToUser");
Console.WriteLine("  Add-Migration AddIndexToProductName");
Console.WriteLine();

// 3. Applying Migrations
Console.WriteLine("=== Applying Migrations ===");
Console.WriteLine("Commands to apply migrations:");
Console.WriteLine("  Package Manager: Update-Database");
Console.WriteLine("  CLI: dotnet ef database update");
Console.WriteLine();
Console.WriteLine("Apply specific migration:");
Console.WriteLine("  Update-Database -Migration MigrationName");
Console.WriteLine();

// 4. Rolling Back Migrations
Console.WriteLine("=== Rolling Back Migrations ===");
Console.WriteLine("To rollback to a previous migration:");
Console.WriteLine("  Update-Database -Migration PreviousMigrationName");
Console.WriteLine();
Console.WriteLine("To remove the last migration (if not applied):");
Console.WriteLine("  Remove-Migration");
Console.WriteLine();

// 5. Migration File Structure
Console.WriteLine("=== Migration File Structure ===");
Console.WriteLine("Each migration file contains:");
Console.WriteLine("  - Up() method: Changes to apply");
Console.WriteLine("  - Down() method: Changes to revert");
Console.WriteLine();
Console.WriteLine("Example migration file:");
Console.WriteLine("  public partial class InitialCreate : Migration");
Console.WriteLine("  {");
Console.WriteLine("      protected override void Up(MigrationBuilder migrationBuilder)");
Console.WriteLine("      {");
Console.WriteLine("          migrationBuilder.CreateTable(...);");
Console.WriteLine("      }");
Console.WriteLine();
Console.WriteLine("      protected override void Down(MigrationBuilder migrationBuilder)");
Console.WriteLine("      {");
Console.WriteLine("          migrationBuilder.DropTable(...);");
Console.WriteLine("      }");
Console.WriteLine("  }");
Console.WriteLine();

// 6. Working with DbContext
Console.WriteLine("=== Working with DbContext ===");
using (var context = new AppDbContext())
{
    // EnsureCreated creates database without migrations
    // In production, use migrations instead
    context.Database.EnsureCreated();
    
    Console.WriteLine("Database created (using EnsureCreated for demo)");
    Console.WriteLine("In production, use migrations:");
    Console.WriteLine("  context.Database.Migrate();");
    Console.WriteLine();
}

// 7. Migration Best Practices
Console.WriteLine("=== Migration Best Practices ===");
Console.WriteLine("1. Always review migration files before applying");
Console.WriteLine("2. Test migrations in development first");
Console.WriteLine("3. Keep migrations small and focused");
Console.WriteLine("4. Never edit applied migrations");
Console.WriteLine("5. Use meaningful migration names");
Console.WriteLine("6. Commit migration files to source control");
Console.WriteLine("7. Apply migrations in order");
Console.WriteLine();

// 8. Scripting Migrations
Console.WriteLine("=== Scripting Migrations ===");
Console.WriteLine("Generate SQL script from migrations:");
Console.WriteLine("  Script-Migration");
Console.WriteLine("  Script-Migration FromMigration ToMigration");
Console.WriteLine();
Console.WriteLine("CLI:");
Console.WriteLine("  dotnet ef migrations script");
Console.WriteLine("  dotnet ef migrations script FromMigration ToMigration");
Console.WriteLine();

// DbContext and Entity

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Using in-memory for demo
        // In real app: optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseInMemoryDatabase("MigrationsDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example configuration
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Price).HasPrecision(18, 2);
            entity.HasIndex(e => e.Name);
        });
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();
}
