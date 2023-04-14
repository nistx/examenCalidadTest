FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinanceApp.web/FinanceApp.web.csproj", "FinanceApp.web/"]
RUN dotnet restore "FinanceApp.web/FinanceApp.web.csproj"
COPY . .
WORKDIR "/src/FinanceApp.web"
RUN dotnet build "FinanceApp.web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceApp.web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinanceApp.web.dll"]
