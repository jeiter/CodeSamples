FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish

COPY --from=build /publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "Library.Api.Hosting.dll"]