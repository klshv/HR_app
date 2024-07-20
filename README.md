# HR_app 
HR_app is a web application for managing employee records within an organization. Built with ASP.NET Core, this backend provides robust API endpoints documented using Swagger and NSwag. The application also leverages Entity Framework for database interactions, transforming C# models into database entities.

## Features

- RESTful API for managing employee records
- Swagger documentation for API endpoints
- NSwag for generating TypeScript client code
- Entity Framework integration for database operations
- Layered architecture for separation of concerns

## Architecture

The application follows a layered architecture to ensure a clear separation of concerns, making it more maintainable and scalable. The main layers are:

1. **Presentation Layer**: Handles HTTP requests and responses. It contains controllers and API endpoints.
2. **Business Logic Layer**: Contains business logic and service classes. This layer processes data between the presentation and data access layers.
3. **Data Access Layer**: Manages database operations using Entity Framework. This layer includes repository classes for data access.

   <img width="467" alt="image" src="https://github.com/user-attachments/assets/a1311355-eca8-4620-958e-8178ec644ba9">
