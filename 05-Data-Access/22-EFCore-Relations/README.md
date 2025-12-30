# 22 - EF Core Relations

## 🎯 Learning Objectives

Learn how to model and work with relationships in Entity Framework Core. Understand one-to-one, one-to-many, and many-to-many relationships.

## 📚 Topics Covered

- One-to-Many relationships
- Many-to-One relationships
- One-to-One relationships
- Many-to-Many relationships
- Navigation properties
- Foreign keys
- Eager loading (Include)
- Lazy loading
- Explicit loading

## 💡 Key Concepts

### Relationships
EF Core supports three main relationship types:
- **One-to-Many**: One entity relates to many entities (e.g., Author has many Books)
- **Many-to-One**: Many entities relate to one entity (e.g., Books belong to one Author)
- **One-to-One**: One entity relates to exactly one entity
- **Many-to-Many**: Many entities relate to many entities

### Navigation Properties
Navigation properties allow you to navigate from one entity to related entities.

### Foreign Keys
Foreign keys establish the relationship between entities at the database level.

### Loading Strategies
- **Eager Loading**: Load related data with Include()
- **Lazy Loading**: Load related data automatically when accessed
- **Explicit Loading**: Manually load related data when needed

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd EFCoreRelations.Sample
dotnet run
```

## 📁 Project Structure

```
22-EFCore-Relations/
├── README.md (this file)
└── EFCoreRelations.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Defining relationships between entities
- Using navigation properties
- Working with foreign keys
- Eager loading related data
- Querying related entities
- Understanding relationship configurations

## ➡️ Next Steps

After mastering EF Core relations, proceed to:
- **23-EFCore-Migrations** - Learn database migrations and schema management

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

