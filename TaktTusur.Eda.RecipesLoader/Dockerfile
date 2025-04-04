FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaktTusur.Eda.RecipesLoader/TaktTusur.Eda.RecipesLoader.csproj", "TaktTusur.Eda.RecipesLoader/"]
RUN dotnet restore "TaktTusur.Eda.RecipesLoader/TaktTusur.Eda.RecipesLoader.csproj"
COPY . .
WORKDIR "/src/TaktTusur.Eda.RecipesLoader"
RUN dotnet build "TaktTusur.Eda.RecipesLoader.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaktTusur.Eda.RecipesLoader.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaktTusur.Eda.RecipesLoader.dll"]
