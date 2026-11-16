# etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish Lab13AlejoMendoza.Persistence \
    -c Release \
    -o /app/publish \
    --no-restore

# etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 10000

ENTRYPOINT ["dotnet", "Lab13AlejoMendoza.Persistence.dll"]