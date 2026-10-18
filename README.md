# Bài thực hành 5 – PricingService và Eureka

Repository này hoàn thiện hai task của bài thực hành: bổ sung implementation `PricingService` vào bộ API/test được cung cấp cho TH5 và đăng ký dịch vụ với Eureka.

## Yêu cầu môi trường

- .NET 8 SDK
- Docker Desktop đang chạy
- Java 8 được đóng gói trong Docker image build Eureka

## Khởi chạy trên Windows PowerShell

1. Tạo file cấu hình local từ mẫu và đặt mật khẩu PostgreSQL:

   ```powershell
   Copy-Item .env.example .env
   notepad .env
   ```

   Điền `POSTGRES_PASSWORD` trong `.env`. File này đã được loại khỏi Git.

2. Khởi chạy Eureka và PostgreSQL:

   ```powershell
   docker compose up --build -d eureka-server postgres
   ```

3. Chờ PostgreSQL sẵn sàng, sau đó cấu hình connection string cho cửa sổ PowerShell hiện tại và chạy dịch vụ:

   ```powershell
   $env:ConnectionStrings__DefaultConnection = "Host=localhost;Port=5432;Database=pricing;Username=postgres;Password=<POSTGRES_PASSWORD>"
   dotnet run --project .\PricingService\PricingService.csproj
   ```

   Thay `<POSTGRES_PASSWORD>` bằng giá trị trong `.env`. `PricingService` khởi tạo dữ liệu biểu phí khi khởi động.

4. Kiểm tra Eureka tại [http://localhost:8761](http://localhost:8761). Trong danh sách instance phải có `PRICINGSERVICE`. API Swagger chạy tại [http://localhost:5040/swagger](http://localhost:5040/swagger).

5. Khi dừng, nhấn `Ctrl+C` trong cửa sổ chạy dịch vụ rồi dùng:

   ```powershell
   docker compose down
   ```

   Lệnh trên giữ volume dữ liệu PostgreSQL. Không thêm `-v` nếu muốn giữ dữ liệu.

## Build và kiểm thử

```powershell
dotnet build .\PricingService.slnx --nologo
dotnet test .\PricingService.slnx --nologo
```

Integration test có thể cần Docker để tạo PostgreSQL riêng.

## Cấu hình Eureka

Máy chủ Eureka lắng nghe cổng `8761`, tắt đăng ký/tải registry cho chính nó và dùng cấu hình trong `eureka-server/eureka-server/src/main/resources/application.yml`. Client `PricingService` dùng package Steeltoe `3.2.7`, đăng ký với `http://localhost:8761/eureka/` và công bố cổng `5040` trong `PricingService/appsettings.json`.

## Minh chứng nộp bài

Task 2 yêu cầu video hoặc PDF ảnh chụp cho thấy Eureka đã chạy trên máy cá nhân và có `PricingService` trong danh sách instance. Chỉ chụp màn hình sau khi thực hiện thành công các bước chạy ở trên; không dùng ảnh mẫu làm minh chứng.
