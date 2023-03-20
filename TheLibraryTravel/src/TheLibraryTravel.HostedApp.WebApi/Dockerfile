#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/TheLibraryTravel.HostedApp.WebApi/TheLibraryTravel.HostedApp.WebApi.csproj", "src/TheLibraryTravel.HostedApp.WebApi/"]
COPY ["src/TheLibraryTravel.WebApi/TheLibraryTravel.WebApi.csproj", "src/TheLibraryTravel.WebApi/"]
COPY ["src/TheLibraryTravel.Aplication/TheLibraryTravel.Aplication.csproj", "src/TheLibraryTravel.Aplication/"]
COPY ["src/TheLibraryTravel.Domain/TheLibraryTravel.Domain.csproj", "src/TheLibraryTravel.Domain/"]
COPY ["src/TheLibraryTravel.Dtos/TheLibraryTravel.Dtos.csproj", "src/TheLibraryTravel.Dtos/"]
COPY ["src/TheLibraryTravel.ObjectMapper.Automapper/TheLibraryTravel.ObjectMapper.Automapper.csproj", "src/TheLibraryTravel.ObjectMapper.Automapper/"]
RUN dotnet restore "src/TheLibraryTravel.HostedApp.WebApi/TheLibraryTravel.HostedApp.WebApi.csproj"
COPY . .
WORKDIR "/src/src/TheLibraryTravel.HostedApp.WebApi"
RUN dotnet build "TheLibraryTravel.HostedApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheLibraryTravel.HostedApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheLibraryTravel.HostedApp.WebApi.dll"]

