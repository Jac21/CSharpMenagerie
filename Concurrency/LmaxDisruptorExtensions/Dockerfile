﻿FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LmaxDisruptorExtensions.csproj", "./"]
RUN dotnet restore "LmaxDisruptorExtensions.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "LmaxDisruptorExtensions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LmaxDisruptorExtensions.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LmaxDisruptorExtensions.dll"]
