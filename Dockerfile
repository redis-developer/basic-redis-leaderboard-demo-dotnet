FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

ENV PORT = 80
ENV REDIS_ENDPOINT_URL "Redis server URI"
ENV REDIS_PASSWORD "Password to the server"

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "BasicRedisLeaderboardDemoDotNetCore/BasicRedisLeaderboardDemoDotNetCore.csproj"

WORKDIR "/src/BasicRedisLeaderboardDemoDotNetCore"
RUN dotnet build "BasicRedisLeaderboardDemoDotNetCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BasicRedisLeaderboardDemoDotNetCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY --from=build /src/BasicRedisLeaderboardDemoDotNetCore/ClientApp/dist ./ClientApp/dist

ENTRYPOINT ["dotnet", "BasicRedisLeaderboardDemoDotNetCore.dll"]