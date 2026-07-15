# Architecture

This projects uses Vertical Slice Architecture.

Each Use Case contains:

- Endpoint
- Request
- Response
- Validator
- Handler

Services layer does not exist.

Persistence will be done by Dapper.

Each slice is independent.

Example:

Features

    Tasks

        Create

            Endpoint.cs
            Request.cs
            Response.cs
            Validator.cs
            Handler.cs

        Search

        Update

        Delete