# Sử dụng image ASP.NET Core runtime làm base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Sử dụng image SDK để build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy file csproj của từng tầng
COPY ["ClinicManagement.API/ClinicManagement.API.csproj", "ClinicManagement.API/"]
COPY ["ClinicManagement.BLL/ClinicManagement.BLL.csproj", "ClinicManagement.BLL/"]
COPY ["ClinicManagement.DAL/ClinicManagement.DAL.csproj", "ClinicManagement.DAL/"]
COPY ["ClinicManagement.Common/ClinicManagement.Common.csproj", "ClinicManagement.Common/"]

# Restore các thư viện
RUN dotnet restore "ClinicManagement.API/ClinicManagement.API.csproj"

# Copy toàn bộ source code còn lại
COPY . .

# Build project
WORKDIR "/src/ClinicManagement.API"
RUN dotnet build "ClinicManagement.API.csproj" -c Release -o /app/build

# Publish ra file chạy
FROM build AS publish
RUN dotnet publish "ClinicManagement.API.csproj" -c Release -o /app/publish

# Tạo image cuối cùng để chạy
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClinicManagement.API.dll"]