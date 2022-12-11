FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdvancedSoftwareTestingMars/AdvancedSoftwareTestingMars.csproj", "AdvancedSoftwareTestingMars/"]
RUN dotnet restore "AdvancedSoftwareTestingMars/AdvancedSoftwareTestingMars.csproj"
COPY . .
WORKDIR "/src/AdvancedSoftwareTestingMars"
RUN dotnet build "AdvancedSoftwareTestingMars.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdvancedSoftwareTestingMars.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdvancedSoftwareTestingMars.dll"]
