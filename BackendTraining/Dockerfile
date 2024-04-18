# See https://aka.ms/customizecontainer for customization options.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# USER app (Ensure this user has the correct permissions or adjust as necessary)
WORKDIR /app
EXPOSE 8081
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackendTraining.csproj", "./"]
RUN dotnet restore "BackendTraining.csproj"

# Copy the rest of the source code
COPY . .
# Assuming all necessary files are in /src after 'COPY . .'
RUN dotnet build "BackendTraining.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
RUN dotnet publish "BackendTraining.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendTraining.dll"]
