FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Gateway/ShopApp.Gateway/ShopApp.Gateway.csproj", "Gateway/ShopApp.Gateway/"]
RUN dotnet restore "Gateway/ShopApp.Gateway/ShopApp.Gateway.csproj"
COPY . .
WORKDIR "/src/Gateway/ShopApp.Gateway"
RUN dotnet build "ShopApp.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopApp.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopApp.Gateway.dll"]