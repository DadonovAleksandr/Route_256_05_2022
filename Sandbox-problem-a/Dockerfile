FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sandbox-problem-a/Sandbox-problem-a.csproj", "Sandbox-problem-a/"]
RUN dotnet restore "Sandbox-problem-a/Sandbox-problem-a.csproj"
COPY . .
WORKDIR "/src/Sandbox-problem-a"
RUN dotnet build "Sandbox-problem-a.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sandbox-problem-a.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sandbox-problem-a.dll"]
