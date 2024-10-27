#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src


COPY ["voting-app/voting-app.sln", "./"]
COPY ["voting-app/voting-app.csproj", "voting-app/"]
COPY ["voting-app-application-layer/voting-app-application-layer.csproj", "voting-app-application-layer/"]
COPY ["voting-app-domain-layer/voting-app-domain-layer.csproj", "voting-app-domain-layer/"]
COPY ["voting-app-infrastructure-layer/voting-app-infrastructure-layer.csproj", "voting-app-infrastructure-layer/"]


RUN dotnet restore "voting-app/voting-app.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./voting-app/voting-app.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./voting-app/voting-app.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "voting-app.dll"]