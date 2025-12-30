# 10 - Structs, Enums & Records

## 🎯 Learning Objectives

Learn about value types (structs), enumerations (enums), and modern C# record types. Understand when to use each and their differences from classes.

## 📚 Topics Covered

- Structs (value types)
- Enums (enumerations)
- Records (C# 9.0+)
- Value types vs reference types
- When to use structs vs classes
- Record types (positional, with expressions)
- Enum flags and bitwise operations

## 💡 Key Concepts

### Structs
Structs are value types that are stored on the stack. They're useful for small data structures that don't require inheritance.

### Enums
Enums are named constants that make code more readable and maintainable.

### Records
Records are immutable reference types introduced in C# 9.0, perfect for data transfer objects and value-based equality.

### Key Differences
- **Classes**: Reference types, stored on heap, support inheritance
- **Structs**: Value types, stored on stack, no inheritance
- **Records**: Reference types with value semantics, immutable by default

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd StructsEnumsRecords.Sample
dotnet run
```

## 📁 Project Structure

```
10-Structs-Enums-Records/
├── README.md (this file)
└── StructsEnumsRecords.Sample/
    └── Program.cs (examples and demonstrations)
```

## 🎓 What You'll Practice

- Creating and using structs
- Working with enums
- Using enum flags
- Creating record types
- Understanding value vs reference semantics
- Using with expressions with records
- Pattern matching with enums

## ➡️ Next Steps

Congratulations! You've completed the Object-Oriented Programming section. Now proceed to:
- **03-Advanced-CSharp** - Learn advanced C# features like generics, delegates, and LINQ

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

