#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Account/Micro.Services.Account/Micro.Services.Account.csproj", "Services/Account/Micro.Services.Account/"]
COPY ["Services/Account/Account.Infrastructure/Account.Infrastructure.csproj", "Services/Account/Account.Infrastructure/"]
COPY ["Services/Account/Account.Application/Account.Application.csproj", "Services/Account/Account.Application/"]
COPY ["Services/Account/Account.Domain/Account.Domain.csproj", "Services/Account/Account.Domain/"]
COPY ["Bus/ACC.Bus.Common/ACC.Bus.Common.csproj", "Bus/ACC.Bus.Common/"]
RUN dotnet restore "Services/Account/Micro.Services.Account/Micro.Services.Account.csproj"
COPY . .
WORKDIR "/src/Services/Account/Micro.Services.Account"
RUN dotnet build "Micro.Services.Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Services.Account.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Services.Account.dll"]