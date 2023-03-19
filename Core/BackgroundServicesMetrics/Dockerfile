FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackgroundServicesMetrics.csproj", "./"]
RUN dotnet restore "BackgroundServicesMetrics.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "BackgroundServicesMetrics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackgroundServicesMetrics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackgroundServicesMetrics.dll"]
