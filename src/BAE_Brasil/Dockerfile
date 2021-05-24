FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BAE_Brasil.Identity/BAE_Brasil.Identity.csproj", "BAE_Brasil.Identity/"]
RUN dotnet restore "BAE_Brasil.Identity/BAE_Brasil.Identity.csproj"
COPY . .
WORKDIR "/src/BAE_Brasil.Identity"
RUN dotnet build "BAE_Brasil.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BAE_Brasil.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BAE_Brasil.Identity.dll"]
