#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ACC/Micro.Services.ACC/Micro.Services.ACC.csproj", "Services/ACC/Micro.Services.ACC/"]
RUN dotnet restore "Services/ACC/Micro.Services.ACC/Micro.Services.ACC.csproj"
COPY . .
WORKDIR "/src/Services/ACC/Micro.Services.ACC"
RUN dotnet build "Micro.Services.ACC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Services.ACC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Services.ACC.dll"]