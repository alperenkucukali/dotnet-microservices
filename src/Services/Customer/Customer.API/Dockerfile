#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Customer/Customer.API/Customer.API.csproj", "Services/Customer/Customer.API/"]
COPY ["BuildingBlocks/Common.Logging/Common.Logging.csproj", "BuildingBlocks/Common.Logging/"]
COPY ["Services/Customer/Customer.Application/Customer.Application.csproj", "Services/Customer/Customer.Application/"]
COPY ["Services/Customer/Customer.Domain/Customer.Domain.csproj", "Services/Customer/Customer.Domain/"]
COPY ["Services/Customer/Customer.Infrastructure/Customer.Infrastructure.csproj", "Services/Customer/Customer.Infrastructure/"]
RUN dotnet restore "./Services/Customer/Customer.API/./Customer.API.csproj"
COPY . .
WORKDIR "/src/Services/Customer/Customer.API"
RUN dotnet build "./Customer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Customer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.API.dll"]