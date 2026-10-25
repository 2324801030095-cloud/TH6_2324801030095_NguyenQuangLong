FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY PolicyService/PolicyService.Api/*.csproj $APP_HOME/PolicyService.Api/
COPY PaymentService/PaymentService.Api/*.csproj $APP_HOME/PaymentService.Api/
COPY PaymentService/PaymentService/*.csproj $APP_HOME/PaymentService/
RUN  cd $APP_HOME/PaymentService && dotnet restore

COPY PolicyService/PolicyService.Api $APP_HOME/PolicyService.Api/
COPY PaymentService/PaymentService.Api $APP_HOME/PaymentService.Api/
COPY PaymentService/PaymentService $APP_HOME/PaymentService/
RUN cd $APP_HOME/PaymentService && dotnet build

COPY PaymentService/PaymentService.Test/*.csproj $APP_HOME/PaymentService.Test/
RUN cd $APP_HOME/PaymentService.Test && dotnet restore

COPY PaymentService/PaymentService.Test .$APP_HOME/PaymentService.Test/
RUN cd $APP_HOME/PaymentService.Test && dotnet build

FROM build AS test
WORKDIR $APP_HOME/PaymentService.Test
RUN dotnet test --verbosity:normal

FROM build AS publish
WORKDIR $APP_HOME/PaymentService
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5070
ENV ASPNETCORE_ENVIRONMENT=docker
COPY --from=publish /opt/app/PaymentService/out ./
ENTRYPOINT ["dotnet", "PaymentService.dll"]