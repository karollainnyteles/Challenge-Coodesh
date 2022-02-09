#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Coodesh.Challenge.Api/Coodesh.Challenge.Api.csproj", "src/Coodesh.Challenge.Api/"]
RUN dotnet restore "src/Coodesh.Challenge.Api/Coodesh.Challenge.Api.csproj"
COPY . .
WORKDIR "/src/src/Coodesh.Challenge.Api"
RUN dotnet build "Coodesh.Challenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coodesh.Challenge.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coodesh.Challenge.Api.dll"]