FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /ClothesstoreApi

# Copy csproj and restore as distinct layers
COPY ClothesstoreProductsAPI/*.sln ./

COPY ClothesstoreProductsAPI/*.csproj ./

COPY XUnitTestClothesstore/*.csproj ./XUnitTestClothesstore/

WORKDIR /ClothesstoreProductsAPI 

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /ClothesstoreProductsAPI
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"