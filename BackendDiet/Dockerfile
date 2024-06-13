# Use SDK to build and publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["GymAppDiet.Api.csproj", "./"]
RUN dotnet restore "GymAppDiet.Api.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "GymAppDiet.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GymAppDiet.Api.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymAppDiet.Api.dll"]
