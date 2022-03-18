#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServiceTests/ServiceTests.csproj", "ServiceTests/"]
RUN dotnet restore "ServiceTests/ServiceTests.csproj"
COPY . .
WORKDIR "/src/ServiceTests"
RUN dotnet build "ServiceTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "ServiceTests.dll"]