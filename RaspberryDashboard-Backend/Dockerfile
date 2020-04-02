#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-buster-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["RaspberryDashboard-Backend/RaspberryDashboard-Backend.csproj", "RaspberryDashboard-Backend/"]
RUN dotnet restore "RaspberryDashboard-Backend/RaspberryDashboard-Backend.csproj"
COPY . .
WORKDIR "/src/RaspberryDashboard-Backend"
RUN dotnet build "RaspberryDashboard-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RaspberryDashboard-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RaspberryDashboard-Backend.dll"]