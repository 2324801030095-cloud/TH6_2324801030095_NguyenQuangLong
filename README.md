# Bài thực hành 6 – API Gateway với Ocelot

Repository này tiếp nối solution microservices của Bài thực hành 5. Bài thực hành 6 cấu hình `AgentPortalApiGateway` bằng Ocelot, dùng Eureka để tìm dịch vụ phía sau và giữ các project AuthService, ChatService, DashboardService cùng các service hiện có trong solution.

## Cấu trúc

- `TH5InsuranceMicroservices.sln`: solution đầy đủ kế thừa từ Bài thực hành 4.
- `PricingService.slnx`: solution con để mở và build riêng PricingService, API và các project kiểm thử.
- `PricingService/`, `PricingService.Api/`, `PricingService.Test/`, `PricingService.IntegrationTest/`: service định giá, hợp đồng API, unit tests và integration tests.
- `eureka-server/eureka-server/`: Eureka server được kế thừa từ Bài thực hành 4.
- `AuthService`, `PolicyService`, `PaymentService`, `ProductService`, `ChatService`, `DashboardService`, `PolicySearchService`, `AgentPortalApiGateway`, `BlazorWasmClient`, `Web`, `postgres`, `scripts`: các thành phần còn lại của solution Bài thực hành 4.
- `evidence/Eureka-PricingService-registered.png`: ảnh chụp khi `PricingService` đã hiển thị `UP` trong Eureka.

## Chạy Agent Portal API Gateway

Gateway cần Eureka đang chạy và giá trị `AppSettings:Secret` giống với AuthService để xác minh JWT. Không lưu secret trong repository; đặt biến môi trường trong phiên PowerShell:

```powershell
$env:AppSettings__Secret = '<same value configured for AuthService>'
docker compose up -d eureka-server
dotnet run --project .\AgentPortalApiGateway\AgentPortalApiGateway\AgentPortalApiGateway.csproj
```

Gateway lắng nghe trên `http://localhost:8099` theo mặc định. Khi chạy trong Docker, `ASPNETCORE_URLS` được ưu tiên để giữ binding của container. `AgentPortalApiGateway/appsettings.json` khai báo tên ứng dụng và Eureka client; các route Ocelot và cấu hình khám phá service nằm trong `AgentPortalApiGateway/ocelot.json`.

Các NuGet Ocelot, Ocelot.Provider.Eureka và Ocelot.Cache.CacheManager đang dùng cùng phiên bản tương thích với target framework .NET 8 của solution.

## Chạy Eureka và PostgreSQL

Cần Docker Desktop với Docker Compose, .NET 8 SDK và kết nối NuGet. Tạo `.env` cục bộ từ mẫu, rồi đặt mật khẩu PostgreSQL trong file đó:

```powershell
Copy-Item .env.example .env
```

Khởi động hạ tầng:

```powershell
docker compose up --build -d eureka-server postgres
```

Đặt connection string cho PricingService trong phiên PowerShell hiện tại, dùng cùng mật khẩu đã đặt trong `.env`:

```powershell
$env:ConnectionStrings__DefaultConnection = 'Host=localhost;Port=5432;Database=pricing;Username=postgres;Password=<POSTGRES_PASSWORD>'
```

Chạy PricingService từ thư mục gốc repository:

```powershell
dotnet run --project .\PricingService
```

Mở <http://localhost:8761> và xác nhận `PRICINGSERVICE` xuất hiện trong danh sách instance với trạng thái `UP` tại cổng `5040`.

Dừng Eureka và PostgreSQL:

```powershell
docker compose down
```

## Build

Build solution kế thừa đầy đủ:

```powershell
dotnet build .\TH5InsuranceMicroservices.sln --nologo
```

Hoặc chỉ build các project PricingService:

```powershell
dotnet build .\PricingService.slnx --nologo
```

## Cấu hình và tệp không đưa lên GitHub

Các `appsettings*.json` kế thừa của những service khác, `.env`, archive RAR, PDF đề, output build và database dump không được đưa vào repository. `PricingService/appsettings.json` là cấu hình Eureka công khai dành riêng cho bài thực hành; launch settings của PricingService được giữ để chạy trên cổng `5040`; mật khẩu database chỉ truyền qua biến môi trường. Tệp `.env.example` chỉ chứa tên biến và giá trị trống.

Các tệp source/asset đã giải nén từ Bài thực hành 4 được giữ lại; file nén gốc và nội dung sinh ra trong `bin`, `obj`, `.vs`, `node_modules` không được sao chép.
