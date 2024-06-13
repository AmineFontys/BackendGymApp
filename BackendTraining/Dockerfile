# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 8082

# SDK image for building and publishing the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files from their actual locations relative to the Docker context
COPY ["BackendTraining/GymAppTraining.Api.csproj", "BackendTraining/GymAppTraining.Api.csproj"]
COPY ["GymApp.Data/GymApp.Data.csproj", "GymApp.Data/GymApp.Data.csproj"]

# Restore the main project's dependencies
RUN dotnet restore "BackendTraining/GymAppTraining.Api.csproj"

# Copy everything else needed for building the project
# Ensure that the Docker context at C:\Users\Amine\VS\BackendGymApp includes all relevant directories and files
COPY . .

# Set work directory to the main project's directory
WORKDIR "/src/BackendTraining"
RUN dotnet build "GymAppTraining.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "GymAppTraining.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Final stage/image using the runtime base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymAppTraining.Api.dll"]
