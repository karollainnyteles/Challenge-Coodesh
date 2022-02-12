#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Coodesh.Challenge.Api/Coodesh.Challenge.Api.csproj", "Coodesh.Challenge.Api/"]
COPY ["./Coodesh.Challenge.Business/Coodesh.Challenge.Business.csproj", "Coodesh.Challenge.Business/"]
COPY ["./Coodesh.Challenge.ClientHttp/Coodesh.Challenge.ClientHttp.csproj", "Coodesh.Challenge.ClientHttp/"]
COPY ["./Coodesh.Challenge.Command/Coodesh.Challenge.Command.csproj", "Coodesh.Challenge.Command/"]
COPY ["./Coodesh.Challenge.Data/Coodesh.Challenge.Data.csproj", "Coodesh.Challenge.Data/"]
COPY ["./Coodesh.Challenge.Query/Coodesh.Challenge.Query.csproj", "Coodesh.Challenge.Query/"]
RUN dotnet restore "./Coodesh.Challenge.Api/Coodesh.Challenge.Api.csproj"
COPY . .
WORKDIR "Coodesh.Challenge.Api"
RUN dotnet build "Coodesh.Challenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coodesh.Challenge.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coodesh.Challenge.Api.dll"]