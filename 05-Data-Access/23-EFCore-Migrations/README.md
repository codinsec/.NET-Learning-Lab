# 23 - EF Core Migrations

## 🎯 Learning Objectives

Master database migrations in Entity Framework Core. Learn how to create, apply, and manage database schema changes using migrations.

## 📚 Topics Covered

- Creating migrations
- Applying migrations
- Rolling back migrations
- Migration files
- Up and Down methods
- Database update commands
- Migration history
- Scripting migrations

## 💡 Key Concepts

### Migrations
Migrations are a way to evolve your database schema over time in a controlled way, keeping it in sync with your entity models.

### Migration Commands
- `Add-Migration`: Creates a new migration
- `Update-Database`: Applies pending migrations
- `Remove-Migration`: Removes the last migration
- `Script-Migration`: Generates SQL script

### Migration Files
Each migration contains:
- **Up()**: Changes to apply the migration
- **Down()**: Changes to revert the migration

### Best Practices
- Always review migration files before applying
- Test migrations in development first
- Keep migrations small and focused
- Never edit applied migrations

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd EFCoreMigrations.Sample
dotnet run
```

## 📁 Project Structure

```
23-EFCore-Migrations/
├── README.md (this file)
└── EFCoreMigrations.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Creating migrations
- Understanding migration files
- Applying migrations
- Rolling back migrations
- Managing database schema changes
- Working with migration history

## ➡️ Next Steps

After mastering EF Core migrations, proceed to:
- **24-Dapper-MiniORM** - Learn Dapper, a lightweight micro-ORM

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

