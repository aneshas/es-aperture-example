FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Bank24.ProjectionWorker/Bank24.ProjectionWorker.csproj", "Bank24.ProjectionWorker/"]
RUN dotnet restore "Bank24.ProjectionWorker/Bank24.ProjectionWorker.csproj"
COPY . .
WORKDIR "/src/Bank24.ProjectionWorker"
RUN dotnet build "Bank24.ProjectionWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank24.ProjectionWorker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank24.ProjectionWorker.dll"]
