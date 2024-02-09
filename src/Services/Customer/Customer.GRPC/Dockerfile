#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Customer/Customer.GRPC/Customer.GRPC.csproj", "Services/Customer/Customer.GRPC/"]
COPY ["BuildingBlocks/Common.Logging/Common.Logging.csproj", "BuildingBlocks/Common.Logging/"]
COPY ["Services/Customer/Customer.Infrastructure/Customer.Infrastructure.csproj", "Services/Customer/Customer.Infrastructure/"]
COPY ["Services/Customer/Customer.Application/Customer.Application.csproj", "Services/Customer/Customer.Application/"]
COPY ["Services/Customer/Customer.Domain/Customer.Domain.csproj", "Services/Customer/Customer.Domain/"]
RUN dotnet restore "./Services/Customer/Customer.GRPC/./Customer.GRPC.csproj"
COPY . .
WORKDIR "/src/Services/Customer/Customer.GRPC"
RUN dotnet build "./Customer.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Customer.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.GRPC.dll"]