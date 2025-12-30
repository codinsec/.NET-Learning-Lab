# 18 - Configuration & Logging

## 🎯 Learning Objectives

Learn how to manage application configuration and implement logging in .NET applications. Master the Configuration and Logging abstractions provided by Microsoft.Extensions.

## 📚 Topics Covered

- Configuration providers (JSON, environment variables, command line)
- Configuration builder pattern
- Reading configuration values
- Strongly-typed configuration
- Logging levels (Trace, Debug, Information, Warning, Error, Critical)
- ILogger interface
- Logging providers (Console, Debug, File)
- Structured logging

## 💡 Key Concepts

### Configuration
Configuration allows you to externalize application settings, making your app environment-aware and easier to configure.

### Logging
Logging provides a way to record application events and errors for debugging, monitoring, and auditing purposes.

### Configuration Sources
- JSON files (appsettings.json)
- Environment variables
- Command-line arguments
- User secrets
- Azure Key Vault

### Logging Levels
- **Trace**: Very detailed information
- **Debug**: Debugging information
- **Information**: General informational messages
- **Warning**: Warning messages
- **Error**: Error messages
- **Critical**: Critical failures

## 🚀 Running the Examples

Navigate to the project folder and run:

```bash
cd ConfigLogging.Sample
dotnet run
```

## 📁 Project Structure

```
18-Config-Logging/
├── README.md (this file)
└── ConfigLogging.Sample/
    ├── Program.cs (examples and demonstrations)
    └── appsettings.json (configuration file)
```

## 🎓 What You'll Practice

- Setting up configuration
- Reading configuration values
- Using strongly-typed configuration
- Implementing logging
- Using different log levels
- Configuring logging providers
- Structured logging

## ➡️ Next Steps

After mastering configuration and logging, proceed to:
- **19-File-IO-Serialization** - Learn file operations and data serialization

---

**Created by:** [Codinsec](https://codinsec.com) | [info@codinsec.com](mailto:info@codinsec.com)  
**Author:** Barbaros Kaymak

