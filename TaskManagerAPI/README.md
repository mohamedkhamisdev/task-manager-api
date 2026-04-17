# Task Manager API

A simple and straightforward ASP.NET Core Web API for managing tasks. This project demonstrates fundamental REST API principles with CRUD operations for task management.

## Prerequisites

- .NET 8 SDK or later ([Download here](https://dotnet.microsoft.com/download))
- Any text editor or IDE (Visual Studio Code, Visual Studio, etc.)
- Basic knowledge of REST APIs and C#

## Quick Start

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/task-manager-api.git
cd task-manager-api
cd TaskManagerAPI
```

### 2. Build the Project

```bash
dotnet build
```

### 3. Run the API

```bash
dotnet run
```

The API will start at `https://localhost:5001` by default. You can test the endpoints using tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/).

## API Endpoints

All endpoints use the base URL: `https://localhost:5001/api/tasks`

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks` | Retrieve all tasks |
| GET | `/api/tasks/{id}` | Retrieve a specific task by ID |
| POST | `/api/tasks` | Create a new task |
| PUT | `/api/tasks/{id}` | Update an existing task |
| DELETE | `/api/tasks/{id}` | Delete a task |

## Request/Response Examples

### Get All Tasks

**Request:**
```http
GET /api/tasks HTTP/1.1
Host: localhost:5001
```

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "title": "Complete project documentation",
    "description": "Write comprehensive documentation for the API",
    "isCompleted": false,
    "createdAt": "2026-04-17T10:30:00Z"
  },
  {
    "id": 2,
    "title": "Deploy to production",
    "description": null,
    "isCompleted": true,
    "createdAt": "2026-04-16T15:45:00Z"
  }
]
```

### Get Task by ID

**Request:**
```http
GET /api/tasks/1 HTTP/1.1
Host: localhost:5001
```

**Response (200 OK):**
```json
{
  "id": 1,
  "title": "Complete project documentation",
  "description": "Write comprehensive documentation for the API",
  "isCompleted": false,
  "createdAt": "2026-04-17T10:30:00Z"
}
```

**Response (404 Not Found):**
```json
null
```

### Create a New Task

**Request:**
```http
POST /api/tasks HTTP/1.1
Host: localhost:5001
Content-Type: application/json

{
  "title": "Review code changes",
  "description": "Perform code review for pull request #42"
}
```

**Response (201 Created):**
```json
{
  "id": 3,
  "title": "Review code changes",
  "description": "Perform code review for pull request #42",
  "isCompleted": false,
  "createdAt": "2026-04-17T12:00:00Z"
}
```

**Response (400 Bad Request):**
```json
"Title is required."
```

### Update a Task

**Request:**
```http
PUT /api/tasks/1 HTTP/1.1
Host: localhost:5001
Content-Type: application/json

{
  "title": "Complete project documentation",
  "isCompleted": true
}
```

**Response (200 OK):**
```json
{
  "id": 1,
  "title": "Complete project documentation",
  "description": "Write comprehensive documentation for the API",
  "isCompleted": true,
  "createdAt": "2026-04-17T10:30:00Z"
}
```

### Delete a Task

**Request:**
```http
DELETE /api/tasks/1 HTTP/1.1
Host: localhost:5001
```

**Response (204 No Content):**
```
(No response body)
```

## Data Model

### Task

| Property | Type | Required | Constraints |
|----------|------|----------|-------------|
| Id | int | Auto-generated | - |
| Title | string | Yes | Max 100 characters |
| Description | string | No | - |
| IsCompleted | bool | No | Defaults to false |
| CreatedAt | DateTime | Auto-generated | UTC timestamp |

## Input Validation

- **Title**: Required, must not exceed 100 characters
- **Description**: Optional
- **IsCompleted**: Optional (defaults to false)

## Architecture

This project uses:
- **ASP.NET Core 8** for the web framework
- **Entity Framework Core** for data access
- **In-Memory Database** for data storage (no external database required)
- **CORS** enabled for cross-origin requests

## Project Structure

```
TaskManagerAPI/
├── Controllers/
│   └── TasksController.cs      # REST API endpoints
├── Data/
│   └── TaskDbContext.cs        # Entity Framework Core context
├── Models/
│   └── Task.cs                 # Task entity model
├── Program.cs                  # Application entry point
├── appsettings.json            # Configuration
├── appsettings.Development.json # Development configuration
└── TaskManagerAPI.csproj       # Project file
```

## Troubleshooting

**Port Already in Use:**
If port 5001 is already in use, you can specify a different port:
```bash
dotnet run --urls="https://localhost:5002"
```

**Entity Framework Issues:**
If you encounter any EF Core issues, the in-memory database is recreated on each application start, so simply restarting the application will reset the data.

## Future Enhancements

- Add persistent database support (SQL Server, PostgreSQL)
- Implement user authentication and authorization
- Add pagination and filtering for task queries
- Implement unit tests
- Add logging and error handling middleware
- Deploy to Azure or AWS

## License

This project is licensed under the MIT License. See the LICENSE file for details.
