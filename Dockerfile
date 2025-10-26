# Use the official .NET 8.0 runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 8.0 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["Gym.Web.csproj", "."]
RUN dotnet restore "Gym.Web.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build "Gym.Web.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Gym.Web.csproj" -c Release -o /app/publish

# Create the final runtime image
FROM base AS final
WORKDIR /app

# Copy the published application
COPY --from=publish /app/publish .

# Set the entry point
ENTRYPOINT ["dotnet", "Gym.Web.dll"]
