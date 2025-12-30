# 28 - ASP.NET Core Authentication

## 🎯 Learning Objectives

Learn authentication and authorization in ASP.NET Core. Master JWT tokens, claims, and securing your APIs.

## 📚 Topics Covered

- Authentication vs Authorization
- JWT (JSON Web Tokens)
- Authentication schemes
- Claims and claims-based identity
- Authorization policies
- Role-based authorization
- Policy-based authorization
- Protecting API endpoints

## 💡 Key Concepts

### Authentication
Authentication is the process of determining who a user is (verifying identity).

### Authorization
Authorization is the process of determining what a user is allowed to do (permissions).

### JWT Tokens
JWT is a compact, URL-safe token format for securely transmitting information between parties.

### Claims
Claims are pieces of information about a user (name, email, role, etc.).

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd AspNetCoreAuthentication.Sample
dotnet run
```

Then test the endpoints:
- POST `/api/auth/login` - Get a JWT token
- GET `/api/products` - Public endpoint
- GET `/api/products/protected` - Requires authentication

## 📁 Project Structure

```
28-AspNetCore-Authentication/
├── README.md (this file)
└── AspNetCoreAuthentication.Sample/
    ├── Program.cs (authentication configuration)
    ├── Controllers/ (API controllers)
    └── Models/ (authentication models)
```

## 🎓 What You'll Practice

- Configuring JWT authentication
- Creating login endpoints
- Protecting API endpoints
- Working with claims
- Implementing authorization policies
- Understanding token validation

## ➡️ Next Steps

Congratulations! You've completed the Web Development section. Now proceed to:
- **07-Testing-Architecture** - Learn testing and software architecture patterns

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

