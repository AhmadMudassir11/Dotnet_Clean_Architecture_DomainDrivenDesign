# Dinner Reservation System

The Dinner Reservation System is a project built using .NET, following the principles of clean architecture and domain-driven design (DDD). It provides a reservation system for managing dinner reservations and offers an organized flow of menus with sections and items. The project utilizes EntityFramework for data storage and implements various design patterns, including the repository pattern. It also incorporates Mapster for object mapping, Dependency Injection for managing dependencies, and JWT Bearer authentication for securing API endpoints.

## Project Structure

The project is structured using a layered architecture approach, separating concerns into different layers. The following layers are used:

### 1. Presentation Layer

The presentation layer handles the user interface and interaction. It may include web API controllers, views, or any other user-facing components. In this project, the presentation layer could consist of:

- Web API controllers for handling reservation requests, menu management, etc.
- User interfaces for managing reservations and menus.

### 2. Application Layer

The application layer contains the application-specific logic and orchestrates the flow of data between the presentation and domain layers. It implements the use cases and business operations of the dinner reservation system. The application layer may include:

- Services for handling reservation operations, menu operations, etc.
- Mapping logic using Mapster for converting DTOs (Data Transfer Objects) to domain entities and vice versa.
- Interfaces defining the application services contracts.
- JWT Bearer authentication setup for securing API endpoints.

### 3. Domain Layer

The domain layer represents the core business logic and contains the domain model, entities, and business rules. It is independent of any infrastructure-specific concerns and encapsulates the fundamental concepts of the dinner reservation system. In this project, the domain layer could consist of:

- Entities representing reservations, menus, sections, and items.
- Value objects representing concepts like dates, names, etc.
- Aggregates defining transactional consistency boundaries.
- Domain services for handling complex business logic not directly tied to an entity.

### 4. Infrastructure Layer

The infrastructure layer provides implementations for interacting with external dependencies and infrastructure-related concerns. It includes data access, repositories, and other infrastructure components. In this project, the infrastructure layer could include:

- Implementations of repository interfaces for data access using Entity Framework.
- Database context and migrations for managing the persistence layer.
- Integration with external services or APIs, if applicable.
- Dependency Injection setup for managing dependencies.

## Getting Started

To get started with the Dinner Reservation System project, follow these steps:

1. Clone the repository: `git clone https://github.com/AhmadMudassir11/dotnet_clean_architecture_DomainDrivenDesign.git`
2. Set up the database and run the necessary migrations.
(migration is created in the Infrastructure layer. run the db command dotnet ef database update -p ./BuberDinner.Infrastructure -s ./BuberDinner.Api)
3. Configure the Mapster object mappings and dependency injection bindings.
4. Build and run the project.
5. Access the API endpoints or user interfaces to interact with the dinner reservation system.

## Dependencies

The Dinner Reservation System project has the following dependencies:

- .NET Framework 
- Entity Framework 
- Mapster 
- JWT Bearer 

## Contributing

Contributions to the Dinner Reservation System project are welcome! If you'd like to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and ensure they are properly tested.
4. Submit a pull request describing your changes.
