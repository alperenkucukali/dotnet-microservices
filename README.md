# Distributed Bank

This project is a sample of microservices architecture with .NET 8. 

You can see the overall diagram below here;

![Sample Bank - Dotnet microservice architecture](https://i.postimg.cc/QtB4hWhD/Untitled-2024-09-23-1357-1.png)

## What's Included

### Customer Microservice
* **ASP.NET Core Web API** application and **gRPC Server** application
* **REST API** principles, **CRUD** operations
* Implementing **DDD, CQRS, and Clean Architecture** using best practices
* Build a highly performant inter-service **gRPC** communication
* Developing **CQRS using MediatR, FluentValidation, and AutoMapper** libraries
* **PostgreSQL database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SQL Server when application run
* **Swagger Open API** implementation

### Account Microservice
* **ASP.NET Core Web API** application
* **REST API** principles, **CRUD** operations
* Implementing **DDD, CQRS, and Clean Architecture** using best practices
* Publish Account's transactions using **MassTransit and RabbitMQ**
* Consume Customer **gRPC Service** for inter-service communication
* Developing **CQRS using MediatR, FluentValidation, and AutoMapper** libraries
* **PostgreSQL database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SQL Server when application run
* **Swagger Open API** implementation

### Transaction Microservice
* **ASP.NET Core Web API** application
* **REST API** principles, **CRUD** operations
* **Repository Pattern** Implementation
* Consume Account's transactions using **MassTransit and RabbitMQ**
* **MongoDB database** connection and containerization
* **Swagger Open API** implementation

### API Gateway(Ocelot) Microservice
- Implement **API Gateways with Ocelot**
- Sample microservices/containers to reroute through the API Gateways
- Run multiple different **API Gateway/BFF** container types

### Microservices Cross-Cutting Implementations
- Implementing **Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog** for Microservices
- Use the **HealthChecks** feature in back-end ASP.NET microservices

### Microservices Resilience Implementations
- Making Microservices more **resilient Use IHttpClientFactory** to implement resilient HTTP requests
- Implement **Retry and Circuit Breaker patterns** with exponential backoff with IHttpClientFactory and **Polly policies**

### Supporting Containers
- Use **Portainer** for Container lightweight management UI which allows you to easily manage your different Docker environments
- **pgAdmin PostgreSQL Tools** feature rich Open Source administration and development platform for PostgreSQL

### Docker Compose Setup
- Containerization of microservices
- Containerization of databases
- Override environment variables
