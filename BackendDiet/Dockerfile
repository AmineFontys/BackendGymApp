# Use SDK to build and publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
EXPOSE 8083
EXPOSE 8084

# Assuming BackendDiet directory is directly under the context directory
COPY ["BackendDiet/GymAppDiet.Api.csproj", "./BackendDiet/"]
RUN dotnet restore "BackendDiet/GymAppDiet.Api.csproj"

# Copy the rest of the source code and build
COPY BackendDiet/ ./BackendDiet/
WORKDIR "/src/BackendDiet"
RUN dotnet build "GymAppDiet.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "GymAppDiet.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymAppDiet.Api.dll"]
