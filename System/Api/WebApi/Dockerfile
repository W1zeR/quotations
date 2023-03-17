#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["System/Api/WebApi/WebApi.csproj", "System/Api/WebApi/"]
COPY ["Data/Context/Context.csproj", "Data/Context/"]
COPY ["Service/CategoriesQuotations/CategoriesQuotations.csproj", "Service/CategoriesQuotations/"]
COPY ["Service/Categories/Categories.csproj", "Service/Categories/"]
COPY ["Shared/Common/Common.csproj", "Shared/Common/"]
COPY ["Service/Quotations/Quotations.csproj", "Service/Quotations/"]
COPY ["Service/CategoriesUsers/CategoriesUsers.csproj", "Service/CategoriesUsers/"]
COPY ["Service/Users/Users.csproj", "Service/Users/"]
COPY ["Service/Comments/Comments.csproj", "Service/Comments/"]
COPY ["Service/Subscriptions/Subscriptions.csproj", "Service/Subscriptions/"]
RUN dotnet restore "System/Api/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/System/Api/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]