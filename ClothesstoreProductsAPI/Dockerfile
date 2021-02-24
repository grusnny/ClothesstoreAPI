FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /ClothesstoreApi/ClothesstoreProductsAPI
RUN ls -l

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet --info
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /ClothesstoreApi/ClothesstoreProductsAPI
COPY --from=build-env /ClothesstoreProductsAPI/out .
CMD dotnet ClothesstoreProductsAPI.dll --urls "http://*:$PORT"