# 20 - ADO.NET Basics

## 🎯 Learning Objectives

Learn the fundamentals of ADO.NET, the data access technology in .NET. Understand how to connect to databases, execute queries, and work with data readers.

## 📚 Topics Covered

- Connection strings
- SqlConnection and connection management
- SqlCommand for executing queries
- SqlDataReader for reading data
- Parameters and parameterized queries
- ExecuteNonQuery, ExecuteScalar, ExecuteReader
- Connection pooling
- Using statements for resource management

## 💡 Key Concepts

### ADO.NET
ADO.NET is the data access technology in .NET that provides direct access to databases using providers.

### Connection Management
Always use `using` statements to ensure connections are properly closed and disposed.

### Parameterized Queries
Always use parameters to prevent SQL injection attacks.

### Data Readers
DataReader provides forward-only, read-only access to query results.

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd AdoNetBasics.Sample
dotnet run
```

**Note:** These examples use in-memory data structures to demonstrate ADO.NET concepts without requiring a database connection.

## 📁 Project Structure

```
20-AdoNet-Basics/
├── README.md (this file)
└── AdoNetBasics.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Creating database connections
- Executing SQL commands
- Reading data with DataReader
- Using parameters in queries
- Managing connections properly
- Understanding connection pooling

## ➡️ Next Steps

After mastering ADO.NET basics, proceed to:
- **21-EFCore-Fundamentals** - Learn Entity Framework Core, a modern ORM

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

