#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestTemplate11.WorkerServices/TestTemplate11.WorkerServices.csproj", "src/TestTemplate11.WorkerServices/"]
COPY ["src/TestTemplate11.Core/TestTemplate11.Core.csproj", "src/TestTemplate11.Core/"]
COPY ["src/TestTemplate11.Common/TestTemplate11.Common.csproj", "src/TestTemplate11.Common/"]
RUN dotnet restore "src/TestTemplate11.WorkerServices/TestTemplate11.WorkerServices.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate11.WorkerServices"
RUN dotnet build "TestTemplate11.WorkerServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate11.WorkerServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/TestTemplate11.WorkerServices/entrypoint.sh", "src/entrypoint.sh"]
COPY ["src/TestTemplate11.WorkerServices/wait-for-it.sh", "src/wait-for-it.sh"]
CMD ["/bin/bash", "src/entrypoint.sh"]
