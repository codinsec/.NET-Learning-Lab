# 21 - EF Core Fundamentals

## 🎯 Learning Objectives

Master Entity Framework Core fundamentals. Learn how to use EF Core as an Object-Relational Mapper (ORM) to work with databases using C# objects.

## 📚 Topics Covered

- DbContext and DbSet
- Entity configuration
- CRUD operations (Create, Read, Update, Delete)
- LINQ to Entities
- Query execution
- Change tracking
- SaveChanges
- In-memory database for testing

## 💡 Key Concepts

### Entity Framework Core
EF Core is a lightweight, extensible, open-source ORM that enables .NET developers to work with databases using .NET objects.

### DbContext
DbContext represents a session with the database and is used to query and save instances of your entities.

### DbSet
DbSet represents a collection of entities that can be queried from the database.

### Change Tracking
EF Core tracks changes to entities, allowing you to modify objects and persist changes with SaveChanges().

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd EFCoreFundamentals.Sample
dotnet run
```

## 📁 Project Structure

```
21-EFCore-Fundamentals/
├── README.md (this file)
└── EFCoreFundamentals.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Creating DbContext
- Defining entities
- Performing CRUD operations
- Querying with LINQ
- Understanding change tracking
- Working with in-memory database

## ➡️ Next Steps

After mastering EF Core fundamentals, proceed to:
- **22-EFCore-Relations** - Learn how to model relationships between entities

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

