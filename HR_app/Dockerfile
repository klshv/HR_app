#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HR_app/HR_app.csproj", "HR_app/"]
RUN dotnet restore "HR_app/HR_app.csproj"
COPY . .
WORKDIR "/src/HR_app"
RUN dotnet build "HR_app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HR_app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HR_app.dll"]