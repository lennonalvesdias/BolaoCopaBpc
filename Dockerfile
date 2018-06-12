FROM microsoft/aspnetcore:latest AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:latest AS build
COPY . ./
WORKDIR /Aplicacao/1 - Servicos/Bolao.WebApi/
RUN dotnet restore
RUN dotnet build

FROM build AS publish
RUN dotnet publish -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Bolao.WebApi.dll"]