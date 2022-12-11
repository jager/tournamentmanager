#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TournamentManager.API/TournamentManager.API.csproj", "TournamentManager.API/"]
COPY ["TournamentManager.Application/TournamentManager.Application.csproj", "TournamentManager.Application/"]
COPY ["TournamentManager.Domain/TournamentManager.Domain.csproj", "TournamentManager.Domain/"]
COPY ["TournamentManager.Framework/TournamentManager.Framework.csproj", "TournamentManager.Framework/"]
RUN dotnet restore "TournamentManager.API/TournamentManager.API.csproj"
COPY . .
WORKDIR "/src/TournamentManager.API"
RUN dotnet build "TournamentManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TournamentManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TournamentManager.API.dll"]