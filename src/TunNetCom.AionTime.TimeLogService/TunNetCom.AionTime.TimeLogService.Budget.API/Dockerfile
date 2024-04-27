#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Budget.API/TunNetCom.AionTime.TimeLogService.API.csproj", "src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Budget.API/"]
COPY ["test/TunNetCom_Aion_Test/TunNetCom.AionTime.Test.csproj", "test/TunNetCom_Aion_Test/"]
COPY ["src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Application/TunNetCom.AionTime.TimeLogService.Application.csproj", "src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Application/"]
COPY ["src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Contracts/TunNetCom.AionTime.TimeLogService.Contracts.csproj", "src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Contracts/"]
COPY ["src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Domain/TunNetCom.AionTime.TimeLogService.Domain.csproj", "src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Domain/"]
COPY ["src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Infrastructure/TunNetCom.AionTime.TimeLogService.Infrastructure.csproj", "src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Infrastructure/"]
RUN dotnet restore "./src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Budget.API/TunNetCom.AionTime.TimeLogService.API.csproj"
COPY . .
WORKDIR "/src/src/TunNetCom.AionTime.TimeLogService/TunNetCom.AionTime.TimeLogService.Budget.API"
RUN dotnet build "./TunNetCom.AionTime.TimeLogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TunNetCom.AionTime.TimeLogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TunNetCom.AionTime.TimeLogService.API.dll"]