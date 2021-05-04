FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /src

COPY ["./warehouse-api/src/Warehouse.API", "Warehouse.API/"]
COPY ["./warehouse-api/src/Warehouse.Entities", "Warehouse.Entities/"]
COPY ["./warehouse-api/src/Warehouse.Services", "Warehouse.Services/"]
COPY ./warehouse-api/src/WarehouseAPI.sln .

RUN dotnet restore "Warehouse.API/Warehouse.API.csproj"
COPY . .
WORKDIR "/src/Warehouse.API"
RUN dotnet build "Warehouse.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Warehouse.API.csproj" -c Release -o /app/publish

FROM base AS final

ENV ASPNETCORE_URLS=http://*:8080
ENV URLS=http://*:8080

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Warehouse.API.dll"]