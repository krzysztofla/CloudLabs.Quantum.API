FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CloudLabs.Quantum.API/CloudLabs.Quantum.API.csproj", "CloudLabs.Quantum.API/"]
RUN dotnet restore "src/CloudLabs.Quantum.API/CloudLabs.Quantum.API.csproj"
COPY . .
WORKDIR "/src/CloudLabs.Quantum.API"
RUN dotnet build "CloudLabs.Quantum.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.Quantum.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.Quantum.API.dll"]
