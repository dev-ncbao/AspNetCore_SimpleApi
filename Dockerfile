FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

#ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Catalog.csproj", "./"]
RUN dotnet restore "Catalog.csproj"
COPY . .
RUN dotnet build "Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.csproj" -c Release -o /app/publish /p:UseAppHost=false
# /p:UseAppHost=false: Không tạo ra file exe
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
# /app/publish: lấy tất cả file tạo ra từ publish copy vào /app
ENTRYPOINT ["dotnet", "Catalog.dll"]
