#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LibraryToDoc.API/LibraryToDoc.API.csproj", "LibraryToDoc.API/"]
RUN dotnet restore "LibraryToDoc.API/LibraryToDoc.API.csproj"
COPY . .
WORKDIR "/src/LibraryToDoc.API"
RUN dotnet build "LibraryToDoc.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryToDoc.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryToDoc.API.dll"]