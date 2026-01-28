# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el proyecto y restaura dependencias
COPY ["ApiBackend.csproj", "./"]
RUN dotnet restore

# Copia el resto del código y publica
COPY . .
RUN dotnet publish -c Release -o /out

# Etapa runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Descargar wait-for-it.sh
RUN apt-get update && apt-get install -y curl \
    && curl -o wait-for-it.sh https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh \
    && chmod +x wait-for-it.sh

# Espera a MySQL antes de iniciar la app
ENTRYPOINT ["./wait-for-it.sh", "mysql:3306", "--timeout=60", "--", "dotnet", "ApiBackend.dll"]
