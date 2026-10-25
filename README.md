# Bài thực hành 6 – API Gateway với Ocelot

Repository kế thừa solution TH5. Bài thực hành 6 bổ sung/cấu hình Ocelot trong `AgentPortalApiGateway`, đồng thời đưa code mẫu của giáo viên cho `AuthService`, `ChatService` và `DashboardService` vào solution.

## Thành phần TH6

- `AgentPortalApiGateway/AgentPortalApiGateway`: gateway chạy tại `http://localhost:8099`, cấu hình Ocelot và Eureka nằm trong `ocelot.json` và `appsettings.json`.
- `AuthService`: service xác thực được bổ sung ở TH6.
- `ChatService` và `ChatService.Api`: service chat và hợp đồng API được bổ sung ở TH6.
- `DashboardService`, `DashboardService.Api` và `DashboardService.Test`: service dashboard, hợp đồng API và project kiểm thử được bổ sung ở TH6.
- Các service còn lại, Eureka, Web, Blazor, PostgreSQL và scripts được kế thừa từ TH4/TH5.

## Chạy các thành phần

Cần .NET 8 SDK và Docker Desktop. Eureka và PostgreSQL có thể khởi động từ thư mục gốc:

```powershell
docker compose up --build -d eureka-server postgres
```

Chạy API Gateway:

```powershell
dotnet run --project .\AgentPortalApiGateway\AgentPortalApiGateway
```

Gateway lắng nghe tại `http://localhost:8099`. Giao diện Eureka ở `http://localhost:8761`. Để chạy Web bằng Docker, build từ `Web` và ánh xạ cổng `8081` nếu cổng `8080` đã được dùng:

```powershell
docker build -t th6-web-ui:local .\Web
docker run --rm -p 8081:80 th6-web-ui:local
```

## Build

```powershell
dotnet build .\TH6InsuranceMicroservices.sln --nologo
```

Không chạy test tự động nếu chưa được yêu cầu; integration tests có thể cần Docker và dịch vụ phụ trợ.

## Cấu hình và dữ liệu cục bộ

Không commit `.env`, secrets, database dumps, archive RAR, hoặc output build. Cấu hình cục bộ nhạy cảm nên được truyền qua biến môi trường; giữ các tệp cấu hình và dữ liệu mẫu do giáo viên cung cấp theo quy tắc `.gitignore` hiện có.
