# 14 - Exception Handling

## 🎯 Learning Objectives

Master exception handling in C#. Learn how to properly catch, handle, and throw exceptions to write robust, error-resistant applications.

## 📚 Topics Covered

- try-catch-finally blocks
- Exception types and hierarchy
- Throwing exceptions
- Custom exceptions
- Exception filters (when clause)
- Using statements and exception handling
- Best practices for exception handling

## 💡 Key Concepts

### Exception Handling
Exception handling allows your program to gracefully handle errors and unexpected situations without crashing.

### Exception Hierarchy
- **Exception**: Base class for all exceptions
- **SystemException**: Base for system exceptions
- **ApplicationException**: Base for application exceptions
- **Specific exceptions**: ArgumentException, NullReferenceException, etc.

### Best Practices
- Catch specific exceptions, not general Exception
- Don't catch exceptions you can't handle
- Use finally blocks for cleanup
- Create custom exceptions for domain-specific errors
- Log exceptions appropriately

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd ExceptionHandling.Sample
dotnet run
```

## 📁 Project Structure

```
14-Exception-Handling/
├── README.md (this file)
└── ExceptionHandling.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Using try-catch-finally blocks
- Handling different exception types
- Throwing and rethrowing exceptions
- Creating custom exceptions
- Using exception filters
- Proper resource cleanup
- Exception handling best practices

## ➡️ Next Steps

After mastering exception handling, proceed to:
- **15-Async-Programming** - Learn asynchronous programming with async/await

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

