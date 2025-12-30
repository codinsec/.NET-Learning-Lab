# 29 - Unit Testing

## 🎯 Learning Objectives

Master unit testing in .NET using xUnit. Learn how to write effective unit tests, use mocking frameworks, and follow testing best practices.

## 📚 Topics Covered

- xUnit testing framework
- Test structure (Arrange, Act, Assert)
- Test attributes ([Fact], [Theory])
- Assertions and test expectations
- Mocking with Moq
- Test isolation
- Test naming conventions
- Code coverage concepts

## 💡 Key Concepts

### Unit Testing
Unit tests verify that individual units of code (methods, classes) work correctly in isolation.

### AAA Pattern
- **Arrange**: Set up test data and dependencies
- **Act**: Execute the code under test
- **Assert**: Verify the results

### Mocking
Mocking allows you to create fake dependencies to isolate the code being tested.

### Test Attributes
- `[Fact]`: Single test case
- `[Theory]`: Parameterized test with multiple test cases
- `[InlineData]`: Provides test data for Theory tests

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd UnitTesting.Sample
dotnet test
```

## 📁 Project Structure

```
29-Unit-Testing/
├── README.md (this file)
└── UnitTesting.Sample/
    └── UnitTest1.cs (test examples)
```

## 🎓 What You'll Practice

- Writing unit tests with xUnit
- Using assertions effectively
- Creating mocks with Moq
- Testing different scenarios
- Understanding test isolation
- Following testing best practices

## ➡️ Next Steps

After mastering unit testing, proceed to:
- **30-Integration-Testing** - Learn integration testing for complete workflows

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

