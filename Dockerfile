FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /app
COPY . .
WORKDIR /app/src/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
LABEL org.opencontainers.image.authors="Stanisław Nieradko <stanislaw@nieradko.com>"
WORKDIR /app
COPY --from=build /app/src/Api/out .
CMD [ "dotnet", "CzyDobrze.Api.dll" ]
