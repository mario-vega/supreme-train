# supreme-train

A starter solution for a task management API built with .NET 10, FastEndpoints, Dapper, FluentValidation, and xUnit.

## Structure

- src/Api: web API project
  - Features/Tasks/*: vertical slices for task operations
  - Infrastructure/Persistence: persistence abstractions and placeholder repository
- tests/Api.Tests: test project for handlers and validators

## Getting started

1. Restore packages
   - dotnet restore
2. Build the solution
   - dotnet build
3. Run the API
   - dotnet run --project src/Api

## Notes

The current scaffold intentionally contains the initial architecture and folder structure only. No use cases are implemented yet.
