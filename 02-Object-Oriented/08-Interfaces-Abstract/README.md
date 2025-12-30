# 08 - Interfaces & Abstract Classes

## 🎯 Learning Objectives

Understand interfaces and abstract classes in C#. Learn when to use each and how they enable polymorphism and define contracts for classes.

## 📚 Topics Covered

- Interface declaration and implementation
- Multiple interface implementation
- Interface inheritance
- Abstract classes
- Abstract methods and properties
- Differences between interfaces and abstract classes
- When to use interfaces vs abstract classes

## 💡 Key Concepts

### Interfaces
Interfaces define a contract that classes must implement. They specify what methods and properties a class must have, but not how they're implemented.

### Abstract Classes
Abstract classes are classes that cannot be instantiated directly. They can contain both abstract members (must be implemented) and concrete members (already implemented).

### Key Differences
- **Interfaces**: Multiple inheritance, no implementation, all members public
- **Abstract Classes**: Single inheritance, can have implementation, can have access modifiers

### When to Use
- Use **interfaces** when you need to define a contract that multiple unrelated classes can implement
- Use **abstract classes** when you have a base class with some common implementation

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd InterfacesAbstract.Sample
dotnet run
```

## 📁 Project Structure

```
08-Interfaces-Abstract/
├── README.md (this file)
└── InterfacesAbstract.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Defining and implementing interfaces
- Implementing multiple interfaces
- Creating abstract classes
- Implementing abstract methods
- Understanding when to use interfaces vs abstract classes
- Interface inheritance

## ➡️ Next Steps

After mastering interfaces and abstract classes, proceed to:
- **09-Polymorphism-Encapsulation** - Learn polymorphism and encapsulation in depth

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

