FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./APIGateway.sln ./APIGateway.sln
COPY ./APIGateway/APIGateway.csproj ./APIGateway/APIGateway.csproj

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ./APIGateway.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "APIGateway.dll"]