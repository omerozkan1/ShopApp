FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/Identity/ShopApp.Identity.Api/ShopApp.Identity.Api.csproj", "Services/Identity/ShopApp.Identity.Api/"]
COPY ["Shared/ShopApp.Shared/ShopApp.Shared.csproj", "Shared/ShopApp.Shared/"]
RUN dotnet restore "Services/Identity/ShopApp.Identity.Api/ShopApp.Identity.Api.csproj"
COPY . .
WORKDIR "/src/Services/Identity/ShopApp.Identity.Api"
RUN dotnet build "ShopApp.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopApp.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopApp.Identity.Api.dll"]