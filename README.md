# Ecommerce.Core

A comprehensive ecommerce solution built with .NET 9.0 following Clean Architecture principles and Domain-Driven Design (DDD).

## 🏗️ Architecture

This project implements Clean Architecture with the following layers:

- **Ecom.Core.API** - Web API layer with minimal API endpoints
- **Ecom.Core.Application** - Application services, DTOs, and business logic
- **Ecom.Core.Domain** - Domain entities, value objects, and business rules
- **Ecom.Core.Infrastructure** - Data persistence and external service integrations
- **Ecom.Core.Shared** - Shared kernel with common utilities

## 🚀 Technologies

- **.NET 9.0** - Latest .NET framework
- **Entity Framework Core** - ORM for data access
- **Minimal APIs** - Lightweight API endpoints
- **Autofac** - Dependency injection container
- **Serilog** - Structured logging
- **Docker** - Containerization support
- **xUnit** - Unit testing framework

## 📁 Project Structure

```text
src/
├── Ecom.Core.API/          # Web API layer
│   ├── Endpoints/           # API endpoints
│   ├── Filters/            # API filters
│   └── Middleware/         # Custom middleware
├── Ecom.Core.Application/   # Application layer
│   ├── DTOs/               # Data transfer objects
│   ├── Features/           # Feature-based organization
│   ├── Services/           # Application services
│   └── Validators/         # Input validation
├── Ecom.Core.Domain/        # Domain layer
│   ├── Entities/           # Domain entities
│   ├── ValueObjects/       # Value objects
│   ├── Aggregates/         # Domain aggregates
│   └── Repositories/       # Repository interfaces
├── Ecom.Core.Infrastructure/ # Infrastructure layer
│   ├── Persistence/        # Database context and configurations
│   ├── Repositories/       # Repository implementations
│   └── ExternalServices/   # External service integrations
└── Ecom.Core.Shared/        # Shared kernel
    └── SharedKernel/       # Common utilities and abstractions

test/
├── EcomCore.Application.UnitTests/
├── EcomCore.Domain.UnitTests/
└── EcomCore.Infrastructure.UnitTests/
```

## 🛠️ Getting Started

### Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or VS Code
- SQL Server (or your preferred database)
- Docker (optional)

### Installation

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd Ecommerce.Core
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   - Edit `src/Ecom.Core.API/appsettings.json`
   - Configure your database connection string

4. **Run database migrations**

   ```bash
   dotnet ef database update --project src/Ecom.Core.Infrastructure --startup-project src/Ecom.Core.API
   ```

5. **Build the solution**

   ```bash
   dotnet build
   ```

6. **Run the application**

   ```bash
   dotnet run --project src/Ecom.Core.API
   ```

The API will be available at `https://localhost:7000` (or the port configured in launchSettings.json).

## 🐳 Docker Support

Build and run with Docker:

```bash
docker build -t ecommerce-core .
docker run -p 8080:80 ecommerce-core
```

Or use Docker Compose if available:

```bash
docker-compose up
```

## 🧪 Testing

Run all tests:

```bash
dotnet test
```

Run tests for a specific project:

```bash
dotnet test test/EcomCore.Domain.UnitTests/
```

## 📊 API Documentation

Once the application is running, you can access:

- **Swagger UI**: `https://localhost:7000/swagger`
- **OpenAPI Spec**: `https://localhost:7000/swagger/v1/swagger.json`

## 🔧 Development

### Adding a New Feature

1. Define domain entities in `Ecom.Core.Domain`
2. Create application services in `Ecom.Core.Application`
3. Implement repository in `Ecom.Core.Infrastructure`
4. Add API endpoints in `Ecom.Core.API`
5. Write unit tests

### Database Migrations

Create a new migration:

```bash
dotnet ef migrations add <MigrationName> --project src/Ecom.Core.Infrastructure --startup-project src/Ecom.Core.API
```

Update database:

```bash
dotnet ef database update --project src/Ecom.Core.Infrastructure --startup-project src/Ecom.Core.API
```

## 🔍 Logging

Logs are written to:

- Console (during development)
- Files in `src/Ecom.Core.API/Logs/` directory
- Structured JSON format for easy parsing

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

For support or questions, please open an issue in the repository.
