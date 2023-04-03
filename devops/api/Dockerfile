FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

RUN git clone https://github.com/gnuvinicius/mstar-supply-challenge.git

WORKDIR /app/mstar-supply-challenge/MStarSupplyApi

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app/mstar-supply-challenge/MStarSupplyApi
WORKDIR /app
COPY --from=build-env /app/mstar-supply-challenge/MStarSupplyApi/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "MStarSupplyApi.dll"]