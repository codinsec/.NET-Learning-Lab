# 25 - ASP.NET Core Web API

## 🎯 Learning Objectives

Master ASP.NET Core Web API development. Learn how to build RESTful APIs using controllers and minimal APIs.

## 📚 Topics Covered

- Web API project structure
- Controllers and API endpoints
- HTTP verbs (GET, POST, PUT, DELETE, PATCH)
- Routing and route attributes
- Model binding and validation
- Status codes and responses
- Minimal APIs
- OpenAPI/Swagger integration

## 💡 Key Concepts

### Web API
ASP.NET Core Web API is a framework for building HTTP services that can be consumed by various clients.

### RESTful Principles
- Resources identified by URIs
- Use HTTP methods (GET, POST, PUT, DELETE)
- Stateless communication
- JSON as data format

### Controllers
Controllers handle HTTP requests and return responses. They use attributes for routing and HTTP verbs.

### Minimal APIs
Minimal APIs provide a lightweight alternative to controllers for simple scenarios.

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd AspNetCoreWebAPI.Sample
dotnet run
```

Then open your browser to:
- Swagger UI: `https://localhost:5001/swagger` (or the port shown in console)
- API endpoints: `https://localhost:5001/api/products`

## 📁 Project Structure

```
25-AspNetCore-WebAPI/
├── README.md (this file)
└── AspNetCoreWebAPI.Sample/
    ├── Program.cs (minimal API example)
    ├── Controllers/ (controller-based API)
    └── Models/ (data models)
```

## 🎓 What You'll Practice

- Creating API controllers
- Defining routes and endpoints
- Handling HTTP methods
- Model binding and validation
- Returning appropriate status codes
- Using minimal APIs
- Working with Swagger/OpenAPI

## ➡️ Next Steps

After mastering Web API, proceed to:
- **26-AspNetCore-MVC** - Learn MVC pattern for web applications

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

