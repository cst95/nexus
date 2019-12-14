FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./NexusAPI.sln ./NexusAPI.sln
COPY ./Nexus.API/Nexus.API.csproj ./Nexus.API/Nexus.API.csproj
COPY ./Nexus.Service/Nexus.Service.csproj ./Nexus.Service/Nexus.Service.csproj
COPY ./Nexus.Model/Nexus.Model.csproj ./Nexus.Model/Nexus.Model.csproj
COPY ./Nexus.Repository/Nexus.Repository.csproj ./Nexus.Repository/Nexus.Repository.csproj
COPY ./Nexus.Utility/Nexus.Utility.csproj ./Nexus.Utility/Nexus.Utility.csproj
COPY ./Nexus.RiotApi/Nexus.RiotApi.csproj ./Nexus.RiotApi/Nexus.RiotApi.csproj

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ./NexusAPI.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Nexus.API.dll"]