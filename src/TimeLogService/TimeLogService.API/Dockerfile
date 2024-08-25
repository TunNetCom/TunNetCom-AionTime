#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TimeLogService/TimeLogService.API/TimeLogService.API.csproj", "src/TimeLogService/TimeLogService.API/"]
COPY ["test/TunNetCom_Aion_Test/TunNetCom.AionTime.Test.csproj", "test/TunNetCom_Aion_Test/"]
COPY ["src/TimeLogService/TimeLogService.Application/TimeLogService.Application.csproj", "src/TimeLogService/TimeLogService.Application/"]
COPY ["src/TimeLogService/TimeLogService.Contracts/TimeLogService.Contracts.csproj", "src/TimeLogService/TimeLogService.Contracts/"]
COPY ["src/TimeLogService/TimeLogService.Domain/TimeLogService.Domain.csproj", "src/TimeLogService/TimeLogService.Domain/"]
COPY ["src/TimeLogService/TimeLogService.Infrastructure/TimeLogService.Infrastructure.csproj", "src/TimeLogService/TimeLogService.Infrastructure/"]
RUN dotnet restore "./src/TimeLogService/TimeLogService.API/TimeLogService.API.csproj"
COPY . .
WORKDIR "/src/src/TimeLogService/TimeLogService.API"
RUN dotnet build "./TimeLogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Copy the SSL certificate file
COPY server.crt /usr/local/share/ca-certificates/

# Update CA certificates
RUN update-ca-certificates

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TimeLogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeLogService.API.dll"]