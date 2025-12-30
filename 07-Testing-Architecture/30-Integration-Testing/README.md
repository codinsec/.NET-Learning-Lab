# 30 - Integration Testing

## 🎯 Learning Objectives

Learn integration testing in ASP.NET Core. Understand how to test complete workflows, API endpoints, and database interactions.

## 📚 Topics Covered

- Integration testing concepts
- WebApplicationFactory for testing ASP.NET Core apps
- Testing API endpoints
- Testing with in-memory database
- HTTP client testing
- Test fixtures and setup
- Testing authentication
- End-to-end workflow testing

## 💡 Key Concepts

### Integration Testing
Integration tests verify that multiple components work together correctly, including databases, APIs, and external services.

### WebApplicationFactory
WebApplicationFactory creates a test server for integration testing ASP.NET Core applications.

### In-Memory Database
Using in-memory databases allows testing database interactions without a real database.

### Test Isolation
Each test should be independent and not rely on other tests.

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd IntegrationTesting.Sample
dotnet test
```

## 📁 Project Structure

```
30-Integration-Testing/
├── README.md (this file)
└── IntegrationTesting.Sample/
    └── IntegrationTest1.cs (test examples)
```

## 🎓 What You'll Practice

- Setting up integration tests
- Testing API endpoints
- Working with test servers
- Testing database operations
- Verifying HTTP responses
- Testing complete workflows

## ➡️ Next Steps

After mastering integration testing, proceed to:
- **31-Repository-Pattern** - Learn repository pattern for data access abstraction

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

