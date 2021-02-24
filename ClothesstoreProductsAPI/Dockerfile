FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /ClothesstoreApi

# Copy csproj and restore as distinct layers
RUN ls -l

COPY XUnitTestClothesstore/XUnitTestClothesstore.csproj ./XUnitTestClothesstore/

COPY ClothesstoreProductsAPI/ClothesstoreProductsAPI.csproj ./

COPY ClothesstoreProductsAPI/ClothesstoreProductsAPI.sln ./

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"