// EF Core Relations Examples
using Microsoft.EntityFrameworkCore;

// 1. One-to-Many Relationship
Console.WriteLine("=== One-to-Many Relationship ===");
using (var context = new AppDbContext())
{
    context.Database.EnsureCreated();

    // Create author with books
    if (!context.Authors.Any())
    {
        var author = new Author
        {
            Name = "John Smith",
            Books = new List<Book>
            {
                new Book { Title = "C# Fundamentals", PublishedYear = 2023 },
                new Book { Title = "Advanced C#", PublishedYear = 2024 }
            }
        };
        context.Authors.Add(author);
        context.SaveChanges();
    }

    // Query with navigation property
    var authorWithBooks = context.Authors.Include(a => a.Books).First();
    Console.WriteLine($"Author: {authorWithBooks.Name}");
    Console.WriteLine("Books:");
    foreach (var book in authorWithBooks.Books)
    {
        Console.WriteLine($"  - {book.Title} ({book.PublishedYear})");
    }
}
Console.WriteLine();

// 2. Many-to-One Relationship
Console.WriteLine("=== Many-to-One Relationship ===");
using (var context = new AppDbContext())
{
    var books = context.Books.Include(b => b.Author).ToList();
    Console.WriteLine("Books with Authors:");
    foreach (var book in books)
    {
        Console.WriteLine($"  {book.Title} by {book.Author.Name}");
    }
}
Console.WriteLine();

// 3. One-to-One Relationship
Console.WriteLine("=== One-to-One Relationship ===");
using (var context = new AppDbContext())
{
    if (!context.Users.Any())
    {
        var user = new User
        {
            Username = "john_doe",
            Profile = new UserProfile
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com"
            }
        };
        context.Users.Add(user);
        context.SaveChanges();
    }

    var userWithProfile = context.Users.Include(u => u.Profile).First();
    Console.WriteLine($"User: {userWithProfile.Username}");
    if (userWithProfile.Profile != null)
    {
        Console.WriteLine($"Profile: {userWithProfile.Profile.FirstName} {userWithProfile.Profile.LastName}");
        Console.WriteLine($"Email: {userWithProfile.Profile.Email}");
    }
}
Console.WriteLine();

// 4. Many-to-Many Relationship
Console.WriteLine("=== Many-to-Many Relationship ===");
using (var context = new AppDbContext())
{
    if (!context.Students.Any())
    {
        var student1 = new Student { Name = "Alice" };
        var student2 = new Student { Name = "Bob" };

        var course1 = new Course { Name = "Mathematics" };
        var course2 = new Course { Name = "Physics" };

        student1.Courses.Add(course1);
        student1.Courses.Add(course2);
        student2.Courses.Add(course1);

        context.Students.AddRange(student1, student2);
        context.SaveChanges();
    }

    var students = context.Students.Include(s => s.Courses).ToList();
    Console.WriteLine("Students and their Courses:");
    foreach (var student in students)
    {
        Console.WriteLine($"  {student.Name}:");
        foreach (var course in student.Courses)
        {
            Console.WriteLine($"    - {course.Name}");
        }
    }
}
Console.WriteLine();

// 5. Querying Related Data
Console.WriteLine("=== Querying Related Data ===");
using (var context = new AppDbContext())
{
    // Find books by author name
    var booksByAuthor = context.Books
        .Where(b => b.Author.Name == "John Smith")
        .ToList();
    Console.WriteLine("Books by John Smith:");
    foreach (var book in booksByAuthor)
    {
        Console.WriteLine($"  {book.Title}");
    }
    Console.WriteLine();

    // Find authors with more than one book
    var authorsWithMultipleBooks = context.Authors
        .Where(a => a.Books.Count > 1)
        .ToList();
    Console.WriteLine("Authors with multiple books:");
    foreach (var authorItem in authorsWithMultipleBooks)
    {
        Console.WriteLine($"  {authorItem.Name} ({authorItem.Books.Count} books)");
    }
}
Console.WriteLine();

// DbContext and Entities

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("RelationsDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure one-to-one relationship
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId);

        // Configure many-to-many relationship
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students);
    }
}

// One-to-Many: Author has many Books
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = new();
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}

// One-to-One: User has one Profile
public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public UserProfile? Profile { get; set; }
}

public class UserProfile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public User User { get; set; } = null!;
}

// Many-to-Many: Students and Courses
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Course> Courses { get; set; } = new();
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new();
}
