// EF Core Fundamentals Examples
using Microsoft.EntityFrameworkCore;

// 1. Create and Seed Database
Console.WriteLine("=== Creating and Seeding Database ===");
using (var context = new AppDbContext())
{
    context.Database.EnsureCreated();

    // Seed data if empty
    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product { Name = "Laptop", Price = 999.99m, Category = "Electronics" },
            new Product { Name = "Mouse", Price = 29.99m, Category = "Electronics" },
            new Product { Name = "Desk", Price = 199.99m, Category = "Furniture" }
        );
        context.SaveChanges();
        Console.WriteLine("Database seeded with initial data");
    }
}
Console.WriteLine();

// 2. Create (Insert)
Console.WriteLine("=== Create (Insert) ===");
using (var context = new AppDbContext())
{
    var newProduct = new Product
    {
        Name = "Keyboard",
        Price = 79.99m,
        Category = "Electronics"
    };
    context.Products.Add(newProduct);
    context.SaveChanges();
    Console.WriteLine($"Created product: {newProduct.Name} with ID: {newProduct.Id}");
}
Console.WriteLine();

// 3. Read (Query)
Console.WriteLine("=== Read (Query) ===");
using (var context = new AppDbContext())
{
    // Get all products
    var allProducts = context.Products.ToList();
    Console.WriteLine("All Products:");
    foreach (var product in allProducts)
    {
        Console.WriteLine($"  {product.Id}: {product.Name} - ${product.Price:F2}");
    }
    Console.WriteLine();

    // Get by ID
    var foundProduct = context.Products.Find(1);
    if (foundProduct != null)
    {
        Console.WriteLine($"Product with ID 1: {foundProduct.Name}");
    }
    Console.WriteLine();

    // LINQ queries
    var electronics = context.Products
        .Where(p => p.Category == "Electronics")
        .ToList();
    Console.WriteLine("Electronics:");
    foreach (var item in electronics)
    {
        Console.WriteLine($"  {item.Name} - ${item.Price:F2}");
    }
    Console.WriteLine();

    var expensiveProducts = context.Products
        .Where(p => p.Price > 100)
        .OrderByDescending(p => p.Price)
        .ToList();
    Console.WriteLine("Products over $100:");
    foreach (var item in expensiveProducts)
    {
        Console.WriteLine($"  {item.Name} - ${item.Price:F2}");
    }
}
Console.WriteLine();

// 4. Update
Console.WriteLine("=== Update ===");
using (var context = new AppDbContext())
{
    var productToUpdate = context.Products.Find(1);
    if (productToUpdate != null)
    {
        Console.WriteLine($"Before update: {productToUpdate.Name} - ${productToUpdate.Price:F2}");
        productToUpdate.Price = 899.99m;
        context.SaveChanges();
        Console.WriteLine($"After update: {productToUpdate.Name} - ${productToUpdate.Price:F2}");
    }
}
Console.WriteLine();

// 5. Delete
Console.WriteLine("=== Delete ===");
using (var context = new AppDbContext())
{
    var product = context.Products.FirstOrDefault(p => p.Name == "Keyboard");
    if (product != null)
    {
        context.Products.Remove(product);
        context.SaveChanges();
        Console.WriteLine($"Deleted product: {product.Name}");
    }
}
Console.WriteLine();

// 6. First, FirstOrDefault, Single, SingleOrDefault
Console.WriteLine("=== Query Methods ===");
using (var context = new AppDbContext())
{
    var firstProduct = context.Products.First();
    Console.WriteLine($"First product: {firstProduct.Name}");

    var firstElectronics = context.Products.FirstOrDefault(p => p.Category == "Electronics");
    Console.WriteLine($"First electronics: {firstElectronics?.Name}");

    var singleProduct = context.Products.Single(p => p.Id == 1);
    Console.WriteLine($"Single product with ID 1: {singleProduct.Name}");

    var count = context.Products.Count();
    Console.WriteLine($"Total products: {count}");
}
Console.WriteLine();

// 7. Change Tracking
Console.WriteLine("=== Change Tracking ===");
using (var context = new AppDbContext())
{
    var product = context.Products.Find(1);
    if (product != null)
    {
        Console.WriteLine($"Original price: ${product.Price:F2}");
        
        // Modify entity
        product.Price = 799.99m;
        
        // Check if entity is modified
        var entry = context.Entry(product);
        Console.WriteLine($"Entity state: {entry.State}");
        Console.WriteLine($"Price changed: {entry.Property(p => p.Price).IsModified}");
        
        context.SaveChanges();
        Console.WriteLine("Changes saved");
    }
}
Console.WriteLine();

// DbContext and Entity

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Using in-memory database for examples
        optionsBuilder.UseInMemoryDatabase("LearningLabDb");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
}
