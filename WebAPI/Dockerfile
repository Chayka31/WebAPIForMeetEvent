# Dockerfile
# Базовый образ с .NET 8 SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файл проекта и восстанавливаем зависимости
COPY WebAPI.csproj .
RUN dotnet restore

# Копируем все остальные файлы и собираем приложение
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Финальный образ с .NET 8 runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Копируем собранное приложение из образа сборки
COPY --from=build /app/publish .

# Открываем порт 8080
EXPOSE 8080
EXPOSE 8081

# Запускаем приложение
ENTRYPOINT ["dotnet", "WebAPI.dll"]