# TaskManagerAPI - API Overview

## API Documentation

This document provides an overview of the TaskManagerAPI endpoints and their usage.

### Base URL
```
http://localhost:5000/api
```

### API Version
- **Current Version**: 1.0
- **OpenAPI/Swagger**: 3.0

---

## Endpoints

### 1. Get All Tasks
**Method**: `GET`  
**Endpoint**: `/api/Tasks`  
**Description**: Retrieve all tasks from the database

**Response**: 
- Status: `200 OK`
- Body: Array of TaskItem objects

---

### 2. Create New Task
**Method**: `POST`  
**Endpoint**: `/api/Tasks`  
**Description**: Create a new task

**Request Body**: 
```json
{
  "title": "string",
  "description": "string",
  "isCompleted": boolean,
  "createdAt": "datetime"
}
```

**Response**: 
- Status: `201 Created`
- Body: Created TaskItem object

---

### 3. Get Task by ID
**Method**: `GET`  
**Endpoint**: `/api/Tasks/{id}`  
**Description**: Retrieve a specific task by its ID

**Parameters**:
- `id` (path parameter): The unique identifier of the task

**Response**: 
- Status: `200 OK`
- Body: TaskItem object

---

### 4. Update Task
**Method**: `PUT`  
**Endpoint**: `/api/Tasks/{id}`  
**Description**: Update an existing task

**Parameters**:
- `id` (path parameter): The unique identifier of the task

**Request Body**: 
```json
{
  "title": "string",
  "description": "string",
  "isCompleted": boolean
}
```

**Response**: 
- Status: `200 OK` or `204 No Content`

---

### 5. Delete Task
**Method**: `DELETE`  
**Endpoint**: `/api/Tasks/{id}`  
**Description**: Delete a task by its ID

**Parameters**:
- `id` (path parameter): The unique identifier of the task

**Response**: 
- Status: `204 No Content` (Success)
- Status: `404 Not Found` (Task doesn't exist)

---

## Models

### TaskItem Schema
```json
{
  "id": "integer",
  "title": "string (required)",
  "description": "string (nullable)",
  "isCompleted": "boolean",
  "createdAt": "datetime"
}
```

### CreateTaskRequest Schema
```json
{
  "title": "string",
  "description": "string",
  "isCompleted": "boolean",
  "createdAt": "datetime"
}
```

### UpdateTaskRequest Schema
```json
{
  "title": "string",
  "description": "string",
  "isCompleted": "boolean"
}
```

---

## Running the API

### Start the Development Server
```bash
cd TaskManagerAPI
dotnet run
```

The API will be available at `http://localhost:5000`

### View Swagger Documentation
Once the API is running, visit:
```
http://localhost:5000/swagger/index.html
```

---

## Database

### Technology
- **ORM**: Entity Framework Core 8.0
- **Database**: SQL Server

### Initial Setup
```bash
dotnet ef database update --project TaskManagerAPI/TaskManagerAPI.csproj
```

---

## Schemas Available
1. **CreateTaskRequest** - Request model for creating a new task
2. **TaskItem** - Response model for a task
3. **UpdateTaskRequest** - Request model for updating a task
