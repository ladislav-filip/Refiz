FROM mcr.microsoft.com/dotnet/aspnet:6.0.14-alpine3.17-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0.406-alpine3.17-arm64v8 AS build
WORKDIR /src
COPY ["src/Frontend/Refiz.Razor/Refiz.Razor.csproj", "src/Frontend/Refiz.Razor/"]
COPY ["src/backend/Refiz.Resources/Refiz.Resources.csproj", "src/backend/Refiz.Resources/"]
COPY ["src/Refiz.Application/Refiz.Application.csproj", "src/Refiz.Application/"]
COPY ["src/Refiz.Queries/Refiz.Queries.csproj", "src/Refiz.Queries/"]
COPY ["src/backend/Refiz.Infrastructure/Refiz.Infrastructure.csproj", "src/backend/Refiz.Infrastructure/"]
COPY ["src/backend/Refiz.Domain/Refiz.Domain.csproj", "src/backend/Refiz.Domain/"]
RUN dotnet restore "src/Frontend/Refiz.Razor/Refiz.Razor.csproj"
COPY . .
WORKDIR "/src/src/Frontend/Refiz.Razor"
RUN dotnet build "Refiz.Razor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Refiz.Razor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Refiz.Razor.dll"]
