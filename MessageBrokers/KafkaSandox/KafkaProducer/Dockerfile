FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KafkaProducer.csproj", "./"]
RUN dotnet restore "KafkaProducer.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "KafkaProducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KafkaProducer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KafkaProducer.dll"]
