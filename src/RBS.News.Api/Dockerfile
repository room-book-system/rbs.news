FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RBS.News.Api/RBS.News.Api.csproj", "RBS.News.Api/"]
COPY ["RBS.News.Application/RBS.News.Application.csproj", "RBS.News.Application/"]
COPY ["RBS.News.Domain/RBS.News.Domain.csproj", "RBS.News.Domain/"]
COPY ["RBS.News.Infrastructure/RBS.News.Infrastructure.csproj", "RBS.News.Infrastructure/"]
RUN dotnet restore "RBS.News.Api/RBS.News.Api.csproj"
COPY . .
WORKDIR "/src/RBS.News.Api"
RUN dotnet build "RBS.News.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RBS.News.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RBS.News.Api.dll"]
