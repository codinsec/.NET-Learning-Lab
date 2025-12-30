# 24 - Dapper & Mini ORM

## 🎯 Learning Objectives

Learn Dapper, a lightweight micro-ORM that provides high performance data access. Understand when to use Dapper vs Entity Framework Core.

## 📚 Topics Covered

- Dapper basics
- Query execution
- Parameterized queries
- Mapping results to objects
- Multiple result sets
- Stored procedures
- Transactions with Dapper
- Dapper vs EF Core comparison

## 💡 Key Concepts

### Dapper
Dapper is a simple object mapper for .NET that extends IDbConnection with helper methods for executing queries and mapping results.

### Micro ORM vs Full ORM
- **Dapper (Micro ORM)**: Lightweight, fast, minimal overhead, manual SQL
- **EF Core (Full ORM)**: Feature-rich, change tracking, LINQ, migrations

### When to Use Dapper
- Performance-critical applications
- When you need full control over SQL
- Simple CRUD operations
- When you don't need change tracking

### When to Use EF Core
- Complex domain models
- When you need change tracking
- When you want LINQ queries
- When you need migrations

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd DapperMiniORM.Sample
dotnet run
```

**Note:** These examples use simulated data to demonstrate Dapper concepts without requiring a database connection.

## 📁 Project Structure

```
24-Dapper-MiniORM/
├── README.md (this file)
└── DapperMiniORM.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Using Dapper for queries
- Mapping results to objects
- Working with parameters
- Executing stored procedures
- Understanding Dapper's performance benefits
- Comparing Dapper with EF Core

## ➡️ Next Steps

Congratulations! You've completed the Data Access section. Now proceed to:
- **06-Web-Development** - Learn ASP.NET Core and Web API development

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

