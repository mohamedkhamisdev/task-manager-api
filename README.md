# Task Manager API

A production-ready ASP.NET Core Web API for managing tasks with full CRUD functionality.

## Project Structure

This repository contains the following project:

- **[TaskManagerAPI/](TaskManagerAPI/)** - The main ASP.NET Core Web API application

## About TaskManagerAPI

TaskManagerAPI is a RESTful web service built with ASP.NET Core 8 and Entity Framework Core. It provides a simple yet complete task management system suitable for learning REST API development or as a foundation for larger projects.

### Features

- ✅ Complete CRUD operations (Create, Read, Update, Delete)
- ✅ RESTful API design with standard HTTP methods
- ✅ Input validation and error handling
- ✅ In-memory database (no external setup required)
- ✅ CORS support for cross-origin requests
- ✅ Professional documentation and examples

### Quick Links

- [TaskManagerAPI Documentation](TaskManagerAPI/README.md) - Full API documentation, setup instructions, and examples
- [Getting Started](TaskManagerAPI/README.md#quick-start) - Instructions to run the project locally

## Prerequisites

- .NET 8 SDK or later

## Getting Started

```bash
cd TaskManagerAPI
dotnet build
dotnet run
```

The API will be available at `http://localhost:5000`

## API Overview

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks` | Get all tasks |
| GET | `/api/tasks/{id}` | Get a specific task |
| POST | `/api/tasks` | Create a new task |
| PUT | `/api/tasks/{id}` | Update a task |
| DELETE | `/api/tasks/{id}` | Delete a task |

For complete documentation, see [TaskManagerAPI/README.md](TaskManagerAPI/README.md).

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.