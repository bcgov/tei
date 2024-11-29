FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["Codes/Codes.Client/Codes.Client.csproj", "Codes/Codes.Client/"]
COPY ["Codes/Codes.Data/Codes.Data.csproj", "Codes/Codes.Data/"]
COPY ["Codes/Codes.Server/Codes.Server.csproj", "Codes/Codes.Server/"]
COPY ["Common/Common.Server/Common.Server.csproj", "Common/Common.Server/"]
COPY ["Database/Database.Data/Database.Data.csproj", "Database/Database.Data/"]
COPY ["Database/Database.Server/Database.Server.csproj", "Database/Database.Server/"]
RUN dotnet restore "Codes/Codes.Server/Codes.Server.csproj"
COPY . .
WORKDIR "/src/Codes/Codes.Server"
RUN dotnet build "Codes.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Codes.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Codes.Server.dll"]
