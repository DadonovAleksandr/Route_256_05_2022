FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sandbox-problem-b/Sandbox-problem-b.csproj", "Sandbox-problem-b/"]
RUN dotnet restore "Sandbox-problem-b/Sandbox-problem-b.csproj"
COPY . .
WORKDIR "/src/Sandbox-problem-b"
RUN dotnet build "Sandbox-problem-b.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sandbox-problem-b.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sandbox-problem-b.dll"]
