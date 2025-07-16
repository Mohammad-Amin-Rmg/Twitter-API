# TwitterApi

A modern ASP.NET Core Web API inspired by Twitter, providing robust user, post, comment, and tag management. Built with .NET 8 and C# 12, this solution leverages Entity Framework Core, Identity, JWT authentication, and Swagger for API documentation.

## Features

- **User Management**: Register, authenticate, update, and delete users with role-based authorization.
- **Post & Comment System**: Create, update, and manage posts and comments.
- **Tagging**: Associate tags with posts for categorization.
- **Views Tracking**: Track post views by users.
- **Secure Authentication**: Uses ASP.NET Core Identity and JWT Bearer tokens.
- **Validation**: Data annotations for model validation.
- **Swagger/OpenAPI**: Interactive API documentation.
- **Utilities**: Helper methods for random string generation, image validation, and avatar path formatting.

## Technologies

- .NET 8, C# 12
- ASP.NET Core Web API
- Entity Framework Core (SQL Server)
- ASP.NET Core Identity
- JWT Authentication
- AutoMapper
- SendGrid (email integration)
- Sieve (filtering/sorting)
- Swagger (Swashbuckle)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server instance

### Setup

1. **Clone the repository**
   
```
   git clone https://github.com/yourusername/TwitterApi.git
   cd TwitterApi
   
```

2. **Configure the database**
   - Update `appsettings.json` with your SQL Server connection string under `ConnectionStrings:DefaultConnection`.

3. **Apply migrations**
   
```
   dotnet ef database update
   
```

4. **Run the application**
   
```
   dotnet run
   
```

5. **Access Swagger UI**
   - Navigate to `https://localhost:5001/swagger` for interactive API documentation.

## API Endpoints

- `POST /api/user` - Create a new user (requires authorization)
- `GET /api/user/get` - Retrieve all users
- `GET /api/user/{id}` - Get user by ID (requires authorization)
- `PUT /api/user/{id}` - Update user
- `DELETE /api/user/{id}` - Delete user

Additional endpoints for posts, comments, tags, and views are available and documented in Swagger.

## Project Structure

- `Controllers/` - API controllers
- `Data/` - Entity models, DbContext, migrations
- `Services/` - Business logic and service interfaces
- `Utilities/` - Helper methods
- `Extensions/` - Application extensions (e.g., migration helpers)

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.


```
**Note:** Update the repository URL and any project-specific details as needed.

```

```
