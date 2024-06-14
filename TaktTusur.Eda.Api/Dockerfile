FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaktTusur.Eda.Api/TaktTusur.Eda.Api.csproj", "TaktTusur.Eda.Api/"]
RUN dotnet restore "TaktTusur.Eda.Api/TaktTusur.Eda.Api.csproj"
COPY . .
WORKDIR "/src/TaktTusur.Eda.Api"
RUN dotnet build "TaktTusur.Eda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaktTusur.Eda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaktTusur.Eda.Api.dll"]
