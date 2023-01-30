FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MySkipList.csproj", "./"]
RUN dotnet restore "MySkipList.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "MySkipList.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MySkipList.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MySkipList.dll"]
