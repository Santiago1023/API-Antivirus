FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE $PORT

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Api-Antivirus/Api-Antivirus.csproj", "Api-Antivirus/"]
RUN dotnet restore "Api-Antivirus/Api-Antivirus.csproj"
COPY . .
WORKDIR "/src/Api-Antivirus"
RUN dotnet build "Api-Antivirus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api-Antivirus.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api-Antivirus.dll"]