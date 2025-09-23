# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Runtime base (ASP.NET Core 9.0 Alpine)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base

# Cài ICU để hỗ trợ CultureInfo (ví dụ vi-VN, ja-JP, en-US...)
RUN apk add --no-cache icu-libs

# Bật globalization đầy đủ (không dùng invariant mode)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

USER $APP_UID
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyBlog.csproj", "."]
RUN dotnet restore "./MyBlog.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./MyBlog.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MyBlog.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBlog.dll"]
