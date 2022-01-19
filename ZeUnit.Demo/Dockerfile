#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ZeUnit.Demo/ZeUnit.Demo.csproj", "ZeUnit.Demo/"]
COPY ["ZeUnit.Story/ZeUnit.Story.csproj", "ZeUnit.Story/"]
COPY ["ZeUnit/ZeUnit.csproj", "ZeUnit/"]
COPY ["ZeUnit.Lamar/ZeUnit.Lamar.csproj", "ZeUnit.Lamar/"]
COPY ["ZeUnit.Runner.VisualStudio/ZeUnit.Runner.VisualStudio.csproj", "ZeUnit.Runner.VisualStudio/"]
RUN dotnet restore "ZeUnit.Demo/ZeUnit.Demo.csproj"
COPY . .
WORKDIR "/src/ZeUnit.Demo"
RUN dotnet build "ZeUnit.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZeUnit.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZeUnit.Demo.dll"]