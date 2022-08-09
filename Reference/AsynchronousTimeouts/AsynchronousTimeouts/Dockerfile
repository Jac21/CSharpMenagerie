FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AsynchronousTimeouts/AsynchronousTimeouts.csproj", "AsynchronousTimeouts/"]
RUN dotnet restore "AsynchronousTimeouts/AsynchronousTimeouts.csproj"
COPY . .
WORKDIR "/src/AsynchronousTimeouts"
RUN dotnet build "AsynchronousTimeouts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AsynchronousTimeouts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AsynchronousTimeouts.dll"]
