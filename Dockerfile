FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers

COPY XUnitTestClothesstore/*.csproj ./ClothesstoreApi/XUnitTestClothesstore/

COPY ClothesstoreProductsAPI/*.csproj ./ClothesstoreApi/ClothesstoreProductsAPI/

COPY ClothesstoreProductsAPI/*.sln ./ClothesstoreApi/ClothesstoreProductsAPI/

WORKDIR /app/ClothesstoreApi/XUnitTestClothesstore
RUN ls
WORKDIR /app/ClothesstoreApi/ClothesstoreProductsAPI
RUN ls

RUN dotnet restore 

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"