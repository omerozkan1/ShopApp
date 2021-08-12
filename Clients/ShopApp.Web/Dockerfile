FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Clients/ShopApp.Web/ShopApp.Web.csproj", "Clients/ShopApp.Web/"]
COPY ["Shared/ShopApp.Shared/ShopApp.Shared.csproj", "Shared/ShopApp.Shared/"]
RUN dotnet restore "Clients/ShopApp.Web/ShopApp.Web.csproj"
COPY . .
WORKDIR "/src/Clients/ShopApp.Web"
RUN dotnet build "ShopApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopApp.Web.dll"]