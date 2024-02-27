#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KwikCase/KwikCase.csproj", "KwikCase/"]
RUN dotnet restore "./KwikCase/./KwikCase.csproj"
COPY . .
WORKDIR "/src/KwikCase"
RUN dotnet build "./KwikCase.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM alpine:latest
RUN apk --no-cache add sqlite
WORKDIR /src
COPY initial-db.sqlite /db/
CMD ["sqlite3", "initial-db.sqlite"]

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KwikCase.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KwikCase.dll"]