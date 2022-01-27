FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
COPY ./output /app
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "personApp.dll"]
