FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Route_256_05_2022/Route_256_05_2022.csproj", "Route_256_05_2022/"]
RUN dotnet restore "Route_256_05_2022/Route_256_05_2022.csproj"
COPY . .
WORKDIR "/src/Route_256_05_2022"
RUN dotnet build "Route_256_05_2022.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Route_256_05_2022.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Route_256_05_2022.dll"]
