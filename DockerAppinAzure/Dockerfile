#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DockerAppinAzure/DockerAppinAzure.csproj", "DockerAppinAzure/"]
RUN dotnet restore "DockerAppinAzure/DockerAppinAzure.csproj"
COPY . .
WORKDIR "/src/DockerAppinAzure"
RUN dotnet build "DockerAppinAzure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerAppinAzure.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerAppinAzure.dll"]