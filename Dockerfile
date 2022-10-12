#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Imagen de Produccion
#####################################################################
FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
#####################################################################

#Imagen de Build
#####################################################################
FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine3.15 AS build
WORKDIR /src
COPY ["BackSaludMigrantes.csproj", "."]
RUN dotnet restore "./BackSaludMigrantes.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BackSaludMigrantes.csproj" -c Release -o /app/build
#####################################################################

#Imagen Publish
#####################################################################
FROM build AS publish
RUN dotnet publish "BackSaludMigrantes.csproj" -c Release -o /app/publish

#Mover publish al final
#####################################################################
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENTRYPOINT ["dotnet", "BackSaludMigrantes.dll"] 