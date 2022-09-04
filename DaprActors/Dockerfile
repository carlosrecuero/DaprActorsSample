#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DaprActors/DaprActors.csproj", "DaprActors/"]
RUN dotnet restore "DaprActors/DaprActors.csproj"
COPY . .
WORKDIR "/src/DaprActors"
RUN dotnet build "DaprActors.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprActors.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprActors.dll"]