
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BackEndSVip/BackEndSVip.slnx", "./"]
COPY ["BackEndSVip/BackEndSVip/BackEndSVip.csproj", "BackEndSVip/"]
COPY ["BackEndSVip/BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["BackEndSVip/DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
RUN dotnet restore "SWP391.sln"

COPY . .
WORKDIR "/src"
RUN dotnet build "BackEndSVip.slnx" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackEndSVip.slnx" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackEndSVip.dll"]