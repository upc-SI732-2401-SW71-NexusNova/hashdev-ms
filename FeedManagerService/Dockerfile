#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8020
EXPOSE 8021

# Setting environment variables
ENV ASPNETCORE_HTTPS_PORTS=8021
ENV ASPNETCORE_HTTP_PORTS=8020

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FeedManagerService/FeedManagerService.csproj", "FeedManagerService/"]
RUN dotnet restore "./FeedManagerService/FeedManagerService.csproj"
COPY . .
WORKDIR "/src/FeedManagerService"
RUN dotnet build "./FeedManagerService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FeedManagerService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeedManagerService.dll"]