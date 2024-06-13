# See https://aka.ms/customizecontainer for customization options.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj
COPY ["BackendTraining/GymAppTraining.Api.csproj", "BackendTraining/"]
COPY ["GymApp.Data/GymApp.Data.csproj", "GymApp.Data/"]

# Restore the projects
RUN dotnet restore "BackendTraining/GymAppTraining.Api.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/BackendTraining"
RUN dotnet build "GymAppTraining.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "GymAppTraining.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymAppTraining.Api.dll"]

