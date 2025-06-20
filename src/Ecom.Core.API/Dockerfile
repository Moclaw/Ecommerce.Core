# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["src/Ecom.Core.API/Ecom.Core.API.csproj", "src/Ecom.Core.API/"]
COPY ["src/Ecom.Core.Application/Ecom.Core.Application.csproj", "src/Ecom.Core.Application/"]
COPY ["src/Ecom.Core.Domain/Ecom.Core.Domain.csproj", "src/Ecom.Core.Domain/"]
COPY ["src/Ecom.Core.Infrastructure/Ecom.Core.Infrastructure.csproj", "src/Ecom.Core.Infrastructure/"]

RUN dotnet restore "src/Ecom.Core.API/Ecom.Core.API.csproj"

# Copy source code - fixing the path issue
COPY . .
WORKDIR "/src/src/Ecom.Core.API"
RUN dotnet build "Ecom.Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ecom.Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecom.Core.API.dll"]