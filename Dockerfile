#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src/SmartFarm
COPY ["SmartFarm/SmartFarm.csproj", "SmartFarm/SmartFarm"]
RUN dotnet restore "SmartFarm/SmartFarm.csproj"
COPY . .
WORKDIR "/src/SmartFarm/SmartFarm"
RUN dotnet build "SmartFarm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartFarm.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "SmartFarm.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet SmartFarm.dll