# TH5 Insurance Microservices

This repository carries forward the TH4 insurance microservices solution and adds the TH5 PricingService and Eureka discovery work.

## Stack
- .NET 8, ASP.NET Core, MediatR, PostgreSQL, RabbitMQ, Elasticsearch, Steeltoe Eureka
- Vue SPA and Blazor WebAssembly clients

## Build commands
- Full solution: `dotnet build TH5InsuranceMicroservices.sln --nologo`
- PricingService projects: `dotnet build PricingService.slnx --nologo`
- Run TH5 service: `dotnet run --project ./PricingService`

Do not run tests unless the user requests them. Integration tests may require Docker and external services.

## Project conventions and safety
- Preserve the inherited service/API/test layout and change only what TH5 requires.
- Keep `.env*`, `appsettings*.json` (except the reviewed, public `PricingService/appsettings.json`), secrets, database dumps, archives and build outputs out of Git.
- The full solution includes copied TH4 projects. Eureka and PricingService are the TH5-specific runnable flow.
