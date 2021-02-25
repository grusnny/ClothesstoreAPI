FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers

COPY XUnitTestClothesstore/*.csproj ./ClothesstoreApi/XUnitTestClothesstore/

COPY ClothesstoreProductsAPI/*.csproj ./ClothesstoreApi/ClothesstoreProductsAPI/

COPY ClothesstoreProductsAPI/*.sln ./ClothesstoreApi/ClothesstoreProductsAPI/

WORKDIR /app/ClothesstoreApi/XUnitTestClothesstore

WORKDIR /app/ClothesstoreApi/ClothesstoreProductsAPI

RUN dotnet restore 

WORKDIR /app
# Copy everything else and build
COPY . ./
RUN dotnet publish ClothesstoreApi/ClothesstoreProductsAPI/ClothesstoreProductsAPI.csproj -c Release -o /app/ClothesstoreApi/ClothesstoreProductsAPI/out
WORKDIR /app/ClothesstoreApi/ClothesstoreProductsAPI
RUN ls
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"