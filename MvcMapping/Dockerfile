FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MvcMapping/MvcMapping.csproj", "MvcMapping/"]
RUN dotnet restore "MvcMapping/MvcMapping.csproj"
COPY . .
WORKDIR "/src/MvcMapping"
RUN dotnet build "MvcMapping.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MvcMapping.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MvcMapping.dll"]