FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Basket/ShopApp.Services.Basket.Api/ShopApp.Services.Basket.Api.csproj", "Services/Basket/ShopApp.Services.Basket.Api/"]
COPY ["Shared/ShopApp.Shared/ShopApp.Shared.csproj", "Shared/ShopApp.Shared/"]
RUN dotnet restore "Services/Basket/ShopApp.Services.Basket.Api/ShopApp.Services.Basket.Api.csproj"
COPY . .
WORKDIR "/src/Services/Basket/ShopApp.Services.Basket.Api"
RUN dotnet build "ShopApp.Services.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopApp.Services.Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopApp.Services.Basket.Api.dll"]