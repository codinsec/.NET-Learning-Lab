# 13 - LINQ Queries

## 🎯 Learning Objectives

Master Language Integrated Query (LINQ) in C#. Learn how to query and manipulate data from various sources using a consistent, declarative syntax.

## 📚 Topics Covered

- LINQ to Objects
- Query syntax vs Method syntax
- Filtering (Where)
- Projection (Select, SelectMany)
- Ordering (OrderBy, OrderByDescending)
- Grouping (GroupBy)
- Aggregation (Sum, Average, Count, Min, Max)
- Joining collections
- Set operations (Distinct, Union, Intersect)

## 💡 Key Concepts

### LINQ
LINQ provides a unified way to query data from different sources (collections, databases, XML) using a consistent syntax.

### Query Syntax vs Method Syntax
- **Query Syntax**: SQL-like syntax, more readable for complex queries
- **Method Syntax**: Fluent API, more flexible and composable

### Deferred Execution
LINQ queries are executed lazily - they don't execute until you iterate over the results.

### Common Operations
- **Filtering**: Where
- **Projection**: Select
- **Sorting**: OrderBy, ThenBy
- **Grouping**: GroupBy
- **Aggregation**: Sum, Average, Count, etc.

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd LinqQueries.Sample
dotnet run
```

## 📁 Project Structure

```
13-LINQ-Queries/
├── README.md (this file)
└── LinqQueries.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Writing LINQ queries in both syntaxes
- Filtering and projecting data
- Sorting and grouping collections
- Performing aggregations
- Joining multiple collections
- Using set operations
- Understanding deferred execution

## ➡️ Next Steps

After mastering LINQ, proceed to:
- **14-Exception-Handling** - Learn proper error handling and exception management

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

