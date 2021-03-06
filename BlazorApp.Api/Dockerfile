#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BlazorApp.Api/BlazorApp.Api.csproj", "BlazorApp.Api/"]
COPY ["BlazorApp.Models/BlazorApp.Models.csproj", "BlazorApp.Models/"]
RUN dotnet restore "BlazorApp.Api/BlazorApp.Api.csproj"
COPY . .
WORKDIR "/src/BlazorApp.Api"
RUN dotnet build "BlazorApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorApp.Api.dll"]