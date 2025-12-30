# 26 - ASP.NET Core MVC

## 🎯 Learning Objectives

Learn the Model-View-Controller (MVC) pattern in ASP.NET Core. Build web applications with separation of concerns.

## 📚 Topics Covered

- MVC pattern and architecture
- Controllers and actions
- Views and Razor syntax
- Models and model binding
- ViewData, ViewBag, and TempData
- Layout pages and partial views
- Routing in MVC
- Tag helpers and HTML helpers

## 💡 Key Concepts

### MVC Pattern
- **Model**: Represents data and business logic
- **View**: Represents the UI (HTML)
- **Controller**: Handles user input and coordinates between Model and View

### Razor Syntax
Razor is a markup syntax for embedding server-based code into web pages.

### Routing
MVC uses convention-based routing to map URLs to controller actions.

### View Engines
Razor is the default view engine in ASP.NET Core MVC.

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd AspNetCoreMVC.Sample
dotnet run
```

Then open your browser to the URL shown in the console (typically `https://localhost:5001`).

## 📁 Project Structure

```
26-AspNetCore-MVC/
├── README.md (this file)
└── AspNetCoreMVC.Sample/
    ├── Controllers/ (MVC controllers)
    ├── Views/ (Razor views)
    ├── Models/ (data models)
    └── wwwroot/ (static files)
```

## 🎓 What You'll Practice

- Creating MVC controllers
- Building Razor views
- Working with models
- Understanding routing
- Using layout pages
- Implementing partial views
- Model binding and validation

## ➡️ Next Steps

After mastering MVC, proceed to:
- **27-AspNetCore-Middleware** - Learn middleware pipeline and request processing

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

