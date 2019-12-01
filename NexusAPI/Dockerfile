FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./SummonerAPI.sln ./SummonerAPI.sln
COPY ./SummonerAPI/SummonerAPI.csproj ./SummonerAPI/SummonerAPI.csproj
COPY ./Summoner.Service/Summoner.Service.csproj ./Summoner.Service/Summoner.Service.csproj
COPY ./Summoner.Models/Summoner.Models.csproj ./Summoner.Models/Summoner.Models.csproj
COPY ./Summoner.Repository/Summoner.Repository.csproj ./Summoner.Repository/Summoner.Repository.csproj

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ./SummonerAPI.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "SummonerAPI.dll"]