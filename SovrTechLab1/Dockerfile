# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Копируем файл решения и проект
COPY Laba1Marta.sln ./
COPY SovrTechLab1/*.csproj ./SovrTechLab1/

# Восстанавливаем зависимости
RUN dotnet restore Laba1Marta.sln

# Копируем всё остальное
COPY . .

# Сборка проекта
WORKDIR /src/SovrTechLab1
RUN dotnet publish -c Release -o /app/out

# Этап выполнения
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Открываем порты
EXPOSE 80
EXPOSE 443

# Точка входа
ENTRYPOINT ["dotnet", "Laba1Marta.dll"]
