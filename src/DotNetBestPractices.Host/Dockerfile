FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/DotNetBestPractices.Host/DotNetBestPractices.Host.csproj", "src/DotNetBestPractices.Host/"]
RUN dotnet restore "src/DotNetBestPractices.Host/DotNetBestPractices.Host.csproj"
COPY . .
WORKDIR "/src/src/DotNetBestPractices.Host"
RUN dotnet build "DotNetBestPractices.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetBestPractices.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNetBestPractices.Host.dll"]