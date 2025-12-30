# 17 - Dependency Injection

## 🎯 Learning Objectives

Master Dependency Injection (DI) in .NET. Learn how to use the built-in DI container to create loosely coupled, testable, and maintainable applications.

## 📚 Topics Covered

- Dependency Injection concepts
- Service registration (Singleton, Scoped, Transient)
- Constructor injection
- Service lifetime management
- Service provider and service resolution
- Interface-based design with DI
- Dependency injection container

## 💡 Key Concepts

### Dependency Injection
Dependency Injection is a design pattern that implements Inversion of Control (IoC) to achieve loose coupling between classes.

### Service Lifetimes
- **Transient**: New instance every time
- **Scoped**: One instance per scope (e.g., per request)
- **Singleton**: Single instance for the application lifetime

### Benefits
- Loose coupling
- Testability (easy to mock dependencies)
- Maintainability
- Flexibility

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd DependencyInjection.Sample
dotnet run
```

## 📁 Project Structure

```
17-Dependency-Injection/
├── README.md (this file)
└── DependencyInjection.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Registering services in DI container
- Understanding service lifetimes
- Injecting dependencies via constructor
- Resolving services from container
- Building loosely coupled applications
- Using interfaces with DI

## ➡️ Next Steps

After mastering dependency injection, proceed to:
- **18-Config-Logging** - Learn configuration management and logging

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

