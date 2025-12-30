# 12 - Delegates & Events

## 🎯 Learning Objectives

Master delegates and events in C#, essential for event-driven programming and implementing the observer pattern. Learn how to create flexible, decoupled code.

## 📚 Topics Covered

- Delegate declaration and usage
- Multicast delegates
- Func and Action delegates
- Events and event handlers
- Event-driven programming
- Lambda expressions with delegates
- Anonymous methods

## 💡 Key Concepts

### Delegates
Delegates are type-safe function pointers that allow you to pass methods as parameters. They enable callback mechanisms and event handling.

### Events
Events are a special type of delegate that provides a way for classes to notify other classes when something happens. They follow the publisher-subscriber pattern.

### Func and Action
- **Func<T>**: Delegate that returns a value
- **Action**: Delegate that performs an action (returns void)

### Benefits
- Decoupling: Publishers don't need to know about subscribers
- Flexibility: Multiple handlers can be attached
- Type safety: Compile-time checking

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd DelegatesEvents.Sample
dotnet run
```

## 📁 Project Structure

```
12-Delegates-Events/
├── README.md (this file)
└── DelegatesEvents.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Creating and using delegates
- Working with multicast delegates
- Implementing events
- Using Func and Action delegates
- Writing lambda expressions
- Building event-driven applications

## ➡️ Next Steps

After mastering delegates and events, proceed to:
- **13-LINQ-Queries** - Learn Language Integrated Query for data manipulation

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

