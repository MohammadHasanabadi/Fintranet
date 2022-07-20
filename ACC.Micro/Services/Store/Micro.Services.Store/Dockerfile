#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Store/Micro.Services.Store/Micro.Services.Store.csproj", "Services/Store/Micro.Services.Store/"]
COPY ["Services/Store/Store.Application/Store.Application.csproj", "Services/Store/Store.Application/"]
COPY ["Services/Store/Store.Domain/Store.Domain.csproj", "Services/Store/Store.Domain/"]
COPY ["Services/Store/Store.Infrastructure/Store.Infrastructure.csproj", "Services/Store/Store.Infrastructure/"]
RUN dotnet restore "Services/Store/Micro.Services.Store/Micro.Services.Store.csproj"
COPY . .
WORKDIR "/src/Services/Store/Micro.Services.Store"
RUN dotnet build "Micro.Services.Store.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Services.Store.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Services.Store.dll"]