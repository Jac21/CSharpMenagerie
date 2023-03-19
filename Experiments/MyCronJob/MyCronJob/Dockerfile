FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyCronJob/MyCronJob.csproj", "MyCronJob/"]
RUN dotnet restore "MyCronJob/MyCronJob.csproj"
COPY . .
WORKDIR "/src/MyCronJob"
RUN dotnet build "MyCronJob.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCronJob.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCronJob.dll"]
