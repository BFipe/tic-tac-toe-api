#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["webapi-tic-tac-toe/webapi-tic-tac-toe.csproj", "webapi-tic-tac-toe/"]
COPY ["webapi-tic-tac-toe.business/webapi-tic-tac-toe.business.csproj", "webapi-tic-tac-toe.business/"]
COPY ["webapi-tic-tac-toe.data/webapi-tic-tac-toe.data.csproj", "webapi-tic-tac-toe.data/"]
COPY ["webapi-tic-tac-toe.entities/webapi-tic-tac-toe.entities.csproj", "webapi-tic-tac-toe.entities/"]
COPY ["webapi-tic-tac-toe.exceptions/webapi-tic-tac-toe.exceptions.csproj", "webapi-tic-tac-toe.exceptions/"]
RUN dotnet restore "webapi-tic-tac-toe/webapi-tic-tac-toe.csproj"
COPY . .
WORKDIR "/src/webapi-tic-tac-toe"
RUN dotnet build "webapi-tic-tac-toe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi-tic-tac-toe.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi-tic-tac-toe.dll"]