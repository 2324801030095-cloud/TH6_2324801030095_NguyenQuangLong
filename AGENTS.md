# TH5 PricingService and Eureka

This .NET 8 submission contains the insurance pricing microservice, its supplied tests, and the Eureka server used for service discovery.

## Commands

- Build: `dotnet build .\PricingService.slnx --nologo`
- Unit and integration tests: `dotnet test .\PricingService.slnx --nologo`
- Run the Eureka server and PostgreSQL: `docker compose up --build -d eureka-server postgres`
- Run PricingService after configuring `ConnectionStrings__DefaultConnection`: `dotnet run --project .\PricingService\PricingService.csproj`

## Layout

- `PricingService/`: ASP.NET Core implementation and Eureka client configuration.
- `PricingService.Api/`: shared pricing API contracts supplied for TH5.
- `PricingService.Test/`, `PricingService.IntegrationTest/`: supplied unit and integration tests.
- `eureka-server/`: supplied Spring Boot Eureka server and `application.yml` on port 8761.

## Gotchas

- PricingService seeds tariffs on startup and needs a reachable PostgreSQL database.
- Set `ConnectionStrings__DefaultConnection` to the same PostgreSQL instance started by Docker Compose.
- Keep `.env` and machine-specific `appsettings.*.json` files local; `.env.example` contains variable names only.
- Eureka client registration is configured for `localhost:8761` and PricingService listens on port 5040.
