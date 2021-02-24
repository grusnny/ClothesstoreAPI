FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
RUN ls -l

COPY src /ClothesstoreApi /XUnitTestClothesstore /*.csproj ./XUnitTestClothesstore/

COPY src /ClothesstoreApi /ClothesstoreProductsAPI /*.csproj ./

COPY src /ClothesstoreApi /ClothesstoreProductsAPI /*.sln ./

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"