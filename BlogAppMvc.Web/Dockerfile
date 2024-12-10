# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BlogAppMvc.Web/BlogAppMvc.Web.csproj", "BlogAppMvc.Web/"]
COPY ["BlogApp.Service/BlogApp.Service.csproj", "BlogApp.Service/"]
COPY ["BlogApp.Dal/BlogApp.Dal.csproj", "BlogApp.Dal/"]
COPY ["BlogApp.Core/BlogApp.Core.csproj", "BlogApp.Core/"]
RUN dotnet restore "./BlogAppMvc.Web/BlogAppMvc.Web.csproj"
COPY . .
WORKDIR "/src/BlogAppMvc.Web"
RUN dotnet build "./BlogAppMvc.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BlogAppMvc.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogAppMvc.Web.dll"]
