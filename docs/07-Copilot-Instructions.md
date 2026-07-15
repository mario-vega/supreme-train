# Agent instructions

Always use:

- .NET 10
- FastEndpoints
- Vertical Slice Architecture
- Dapper
- FluentValidation
- SQL Server
- Error Logging

Do not use:

- Entity Framework
- Controllers
- Services
- AutoMapper

Each use case should contain:

- Endpoint
- Request
- Response
- Validator
- Handler

Code must follow SOLID principles and be testable.

Use async/await for all I/O operations.

All SQL querys must be parameterized to prevent SQL injection.

Generate a README.md file with instructions to run the project and a Postman collection to test the endpoints.

Gereate unit tests for all handlers and validators.