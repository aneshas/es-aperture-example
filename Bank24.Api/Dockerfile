FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Bank24.Api/Bank24.Api.csproj", "Bank24.Api/"]
RUN dotnet restore "Bank24.Api/Bank24.Api.csproj"
COPY . .
WORKDIR "/src/Bank24.Api"
RUN dotnet build "Bank24.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank24.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank24.Api.dll"]
