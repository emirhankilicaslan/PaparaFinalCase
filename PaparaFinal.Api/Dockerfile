FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PaparaFinal.Api/PaparaFinal.Api.csproj", "PaparaFinal.Api/"]
RUN dotnet restore "PaparaFinal.Api/PaparaFinal.Api.csproj"
COPY . .
WORKDIR "/src/PaparaFinal.Api"
RUN dotnet build "PaparaFinal.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PaparaFinal.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaparaFinal.Api.dll"]
