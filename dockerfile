# Usar la imagen base de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos del proyecto y restaurar las dependencias
COPY OptimalRouteAPI/OptimalRouteAPI.csproj OptimalRouteAPI/
RUN dotnet restore "OptimalRouteAPI/OptimalRouteAPI.csproj"

# Copiar el resto del código fuente
COPY . .

# Compilar la aplicación
WORKDIR "/src/OptimalRouteAPI"
RUN dotnet build "OptimalRouteAPI.csproj" -c Release -o /app/build

# Publicar la aplicación
RUN dotnet publish "OptimalRouteAPI.csproj" -c Release -o /app/publish

# Usar la imagen base de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de compilación
COPY --from=build /app/publish .

# Exponer el puerto que usa la aplicación (por defecto, 80 para HTTP)
EXPOSE 80

# Definir el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "OptimalRouteAPI.dll"]