FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["drangedal-open-backend/drangedal-open-backend.csproj", "drangedal-open-backend/"]
RUN dotnet restore "drangedal-open-backend/drangedal-open-backend.csproj"
COPY . .
WORKDIR "/src/drangedal-open-backend"
RUN dotnet build "drangedal-open-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "drangedal-open-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "drangedal-open-backend.dll"]
