#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CiklumTasks.API/CiklumTasks.API.csproj", "CiklumTasks.API/"]
COPY ["CiklumTasks.ApplicationServices/CiklumTasks.ApplicationServices.csproj", "CiklumTasks.ApplicationServices/"]
COPY ["CiklumTasks.Repositories/CiklumTasks.Repositories.csproj", "CiklumTasks.Repositories/"]
COPY ["CiklumTasks.Model/CiklumTasks.Model.csproj", "CiklumTasks.Model/"]
COPY ["CiklumTasks.Common/CiklumTasks.Common.csproj", "CiklumTasks.Common/"]
RUN dotnet restore "CiklumTasks.API/CiklumTasks.API.csproj"
COPY . .
WORKDIR "/src/CiklumTasks.API"
RUN dotnet build "CiklumTasks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CiklumTasks.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "CiklumTask.API.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CiklumTask.API.dll
