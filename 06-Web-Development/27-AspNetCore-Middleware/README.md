# 27 - ASP.NET Core Middleware

## 🎯 Learning Objectives

Master the ASP.NET Core middleware pipeline. Learn how to create custom middleware and understand request processing flow.

## 📚 Topics Covered

- Middleware pipeline concept
- Built-in middleware (Authentication, CORS, Routing, etc.)
- Custom middleware creation
- Middleware ordering
- Request and response manipulation
- Exception handling middleware
- Conditional middleware
- Middleware extension methods

## 💡 Key Concepts

### Middleware
Middleware components form a pipeline that handles requests and responses. Each middleware can:
- Process the request before passing to the next middleware
- Process the response after the next middleware completes
- Short-circuit the pipeline (not call next middleware)

### Pipeline Order
The order of middleware matters! Middleware executes in the order they are added.

### Request Pipeline
Request flows through middleware in the order they're registered, response flows back in reverse order.

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd AspNetCoreMiddleware.Sample
dotnet run
```

Then test the endpoints to see middleware in action.

## 📁 Project Structure

```
27-AspNetCore-Middleware/
├── README.md (this file)
└── AspNetCoreMiddleware.Sample/
    ├── Program.cs (middleware configuration)
    └── Middleware/ (custom middleware examples)
```

## 🎓 What You'll Practice

- Understanding middleware pipeline
- Creating custom middleware
- Working with built-in middleware
- Request/response manipulation
- Exception handling
- Middleware ordering

## ➡️ Next Steps

After mastering middleware, proceed to:
- **28-AspNetCore-Authentication** - Learn authentication and authorization

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

