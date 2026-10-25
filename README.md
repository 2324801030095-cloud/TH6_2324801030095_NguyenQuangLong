# Bài thực hành 5 – Eureka và PricingService

Repository này kế thừa solution microservices của Bài thực hành 4. Bài thực hành 5 tiếp tục trên cùng project, bổ sung code cho `PricingService`, cấu hình Eureka Service Registry và kiểm tra đăng ký service. Các project của những service khác được giữ lại để thể hiện trạng thái phát triển nối tiếp giữa hai bài.

## Các bước hoàn thiện project

1. **Bài thực hành 4:** tạo solution và các microservice theo cấu trúc mỗi thư mục service chứa project triển khai, API và kiểm thử.
2. **Bài thực hành 5 – Task 1:** bổ sung code từ ba archive của giáo viên vào `PricingService/PricingService.Api`, `PricingService/PricingService`, `PricingService/PricingService.Test` và `PricingService/PricingService.IntegrationTest`.
3. **Bài thực hành 5 – Task 2:** thêm Eureka server trong `eureka-server`, cấu hình cổng `8761`, đăng ký `PricingService` làm Eureka client và xác nhận service ở cổng `5040`.

## Cấu trúc

- `TH5InsuranceMicroservices.sln`: solution đầy đủ kế thừa từ Bài thực hành 4.
- `PricingService.slnx`: solution con để mở và build riêng PricingService, API và các project kiểm thử.
- `PricingService/PricingService/`, `PricingService/PricingService.Api/`, `PricingService/PricingService.Test/`, `PricingService/PricingService.IntegrationTest/`: service định giá, hợp đồng API, unit tests và integration tests.
- `eureka-server/eureka-server/`: Eureka server được kế thừa từ Bài thực hành 4.
- `AuthService`, `PolicyService`, `PaymentService`, `ProductService`, `ChatService`, `DashboardService`, `PolicySearchService`, `AgentPortalApiGateway`, `BlazorWasmClient`, `Web`, `postgres`, `scripts`: các thành phần còn lại của solution Bài thực hành 4.
- `evidence/Eureka-PricingService-registered.png`: ảnh chụp khi `PricingService` đã hiển thị `UP` trong Eureka.

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
dotnet run --project .\PricingService\PricingService
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

Các `appsettings*.json` kế thừa của những service khác, `.env`, archive RAR, PDF đề, output build và database dump không được đưa vào repository. `PricingService/PricingService/appsettings.json` là cấu hình Eureka công khai dành riêng cho bài thực hành; launch settings của PricingService được giữ để chạy trên cổng `5040`; mật khẩu database chỉ truyền qua biến môi trường. Tệp `.env.example` chỉ chứa tên biến và giá trị trống.

Các tệp source/asset đã giải nén từ Bài thực hành 4 được giữ lại; file nén gốc và nội dung sinh ra trong `bin`, `obj`, `.vs`, `node_modules` không được sao chép.
