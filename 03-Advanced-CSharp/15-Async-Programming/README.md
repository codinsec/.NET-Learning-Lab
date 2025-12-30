# 15 - Async Programming

## 🎯 Learning Objectives

Master asynchronous programming in C# using async/await. Learn how to write non-blocking, responsive applications that can handle I/O operations efficiently.

## 📚 Topics Covered

- async and await keywords
- Task and Task<T>
- Async methods
- Async/await patterns
- Task.Run for CPU-bound work
- Parallel execution
- Exception handling in async code
- Cancellation tokens

## 💡 Key Concepts

### Asynchronous Programming
Asynchronous programming allows your application to perform work without blocking the main thread, improving responsiveness and scalability.

### async/await
- **async**: Marks a method as asynchronous
- **await**: Waits for an asynchronous operation to complete without blocking

### Task and Task<T>
- **Task**: Represents an asynchronous operation that returns void
- **Task<T>**: Represents an asynchronous operation that returns a value of type T

### Benefits
- Better responsiveness: UI doesn't freeze
- Better scalability: Can handle more concurrent operations
- Efficient resource usage: Threads aren't blocked waiting for I/O

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd AsyncProgramming.Sample
dotnet run
```

## 📁 Project Structure

```
15-Async-Programming/
├── README.md (this file)
└── AsyncProgramming.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Writing async methods
- Using await for asynchronous operations
- Running tasks in parallel
- Handling exceptions in async code
- Using cancellation tokens
- Understanding async/await best practices

## ➡️ Next Steps

After mastering async programming, proceed to:
- **16-Reflection-Attributes** - Learn reflection and attributes for metadata programming

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

