# TH6 Insurance Microservices

This repository carries forward the TH4 insurance microservices solution and adds the TH5 PricingService and Eureka discovery work.

## Stack
- .NET 8, ASP.NET Core, MediatR, PostgreSQL, RabbitMQ, Elasticsearch, Steeltoe Eureka
- Vue SPA and Blazor WebAssembly clients

## Build commands
- Full solution: `dotnet build TH6InsuranceMicroservices.sln --nologo`
- PricingService projects: `dotnet build PricingService.slnx --nologo`
- Run TH5 service: `dotnet run --project ./PricingService/PricingService`

Do not run tests unless the user requests them. Integration tests may require Docker and external services.

## Project conventions and safety
- Preserve the inherited service/API/test layout and change only what the TH6 guide requires.
- Keep `.env*`, `appsettings*.json` (except the reviewed, public `PricingService/PricingService/appsettings.json`), secrets, database dumps, archives and build outputs out of Git.
- TH6 adds the Ocelot API Gateway configuration and the teacher-provided AuthService, ChatService, and DashboardService projects. Eureka and PricingService remain inherited from TH5.
