FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./SummonerAPI/SummonerAPI.csproj ./SummonerAPI/SummonerAPI.csproj
COPY ./Summoner.Service/Summoner.Service.csproj ./Summoner.Service/Summoner.Service.csproj
COPY ./Summoner.Models/Summoner.Models.csproj ./Summoner.Models/Summoner.Models.csproj
COPY ./Summoner.Repository/Summoner.Repository.csproj ./Summoner.Repository/Summoner.Repository.csproj

RUN dotnet restore ./SummonerAPI/SummonerAPI.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./SummonerAPI/SummonerAPI.csproj -c Release -o out --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "SummonerAPI.dll"]