# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Motto.MR.Api/Motto.MR.Api.csproj", "Motto.MR.Api/"]
COPY ["Motto.MR.DataAccess/Motto.MR.DataAccess.csproj", "Motto.MR.DataAccess/"]
COPY ["Motto.MR.Domain/Motto.MR.Domain.csproj", "Motto.MR.Domain/"]
COPY ["Motto.MR.Shared/Motto.MR.Shared.csproj", "Motto.MR.Shared/"]
COPY ["Motto.MR.Security/Motto.MR.Security.csproj", "Motto.MR.Security/"]
RUN dotnet restore "./Motto.MR.Api/Motto.MR.Api.csproj"
COPY . .
WORKDIR "/src/Motto.MR.Api"
RUN dotnet build "./Motto.MR.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Motto.MR.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Motto.MR.Api.dll"]