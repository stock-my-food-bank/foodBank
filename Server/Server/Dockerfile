FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5252

ENV ASPNETCORE_URLS=http://+:5252

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Server/Server/Server.csproj", "Server/Server/"]
RUN dotnet restore "Server/Server/Server.csproj"
COPY . .
WORKDIR "/src/Server/Server"
RUN dotnet build "Server.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Server.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Switch to root to change directory ownership
USER root
RUN chown -R app:app /app

# Switch back to app
USER app
ENTRYPOINT ["dotnet", "Server.dll"]
