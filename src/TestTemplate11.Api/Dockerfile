#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestTemplate11.Api/TestTemplate11.Api.csproj", "src/TestTemplate11.Api/"]
COPY ["src/TestTemplate11.Data/TestTemplate11.Data.csproj", "src/TestTemplate11.Data/"]
COPY ["src/TestTemplate11.Common/TestTemplate11.Common.csproj", "src/TestTemplate11.Common/"]
COPY ["src/TestTemplate11.Core/TestTemplate11.Core.csproj", "src/TestTemplate11.Core/"]
RUN dotnet restore "src/TestTemplate11.Api/TestTemplate11.Api.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate11.Api"
RUN dotnet build "TestTemplate11.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate11.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTemplate11.Api.dll"]