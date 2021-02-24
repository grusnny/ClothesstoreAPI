FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers

COPY ./ClothesstoreApi/XUnitTestClothesstore/XUnitTestClothesstore.csproj ./XUnitTestClothesstore/

COPY ./ClothesstoreApi/ClothesstoreProductsAPI/ClothesstoreProductsAPI.csproj ./

COPY ./ClothesstoreApi/ClothesstoreProductsAPI/ClothesstoreProductsAPI.sln ./

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"