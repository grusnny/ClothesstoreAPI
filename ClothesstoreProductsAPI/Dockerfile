FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR ClothesstoreApi/ClothesstoreProductsAPI

# Copy csproj and restore as distinct layers

COPY *.csproj ./

COPY *.sln ./

WORKDIR ClothesstoreApi/XUnitTestClothesstore
COPY *.csproj ./XUnitTestClothesstore/

WORKDIR ClothesstoreApi/ClothesstoreProductsAPI

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"