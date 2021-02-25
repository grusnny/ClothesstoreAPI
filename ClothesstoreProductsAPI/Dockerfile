FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers

COPY *.csproj ./ClothesstoreApi/XUnitTestClothesstore/

COPY *.csproj ./ClothesstoreApi/ClothesstoreProductsAPI/

COPY *.sln ./ClothesstoreApi/ClothesstoreProductsAPI/



WORKDIR /app/ClothesstoreApi/ClothesstoreProductsAPI
RUN ls

RUN dotnet restore 

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"