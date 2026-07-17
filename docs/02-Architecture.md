# Architecture

This projects uses Vertical Slice Architecture.

Each feature contains:

- Endpoint
- Request
- Response
- Validator
- Handler

Services layer does not exist.

Persistence will be done by Dapper.

PATCH endpoints should be managed as partial updates.

Each slice is independent and must contain a Domain folder.

Example:

Features
    Tasks
        Add
            AddTask.cs
            AddTaskRequest.cs
            AddTaskResponse.cs
            AddTaskValidator.cs
            AddTaskHandler.cs
        Search
            Search.cs
            SearchRequest.cs
            SearchResponse.cs
            SearchValidator.cs
            SearchHandler.cs
        Update
        Delete
        Domain