FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleReflectionMapper/SimpleReflectionMapper.csproj", "SimpleReflectionMapper/"]
RUN dotnet restore "SimpleReflectionMapper/SimpleReflectionMapper.csproj"
COPY . .
WORKDIR "/src/SimpleReflectionMapper"
RUN dotnet build "SimpleReflectionMapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleReflectionMapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleReflectionMapper.dll"]
