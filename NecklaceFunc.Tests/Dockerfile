FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NecklaceFunc.Tests/NecklaceFunc.Tests.csproj", "NecklaceFunc.Tests/"]
COPY ["NecklaceFunc/NecklaceFunc.csproj", "NecklaceFunc/"]
COPY ["NecklaceApi/NecklaceApi.csproj", "NecklaceApi/"]
RUN dotnet restore "NecklaceFunc.Tests/NecklaceFunc.Tests.csproj"
COPY . .
WORKDIR "/src/NecklaceFunc.Tests"
RUN dotnet build "NecklaceFunc.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NecklaceFunc.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NecklaceFunc.Tests.dll"]
