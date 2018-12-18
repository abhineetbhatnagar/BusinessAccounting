FROM microsoft/dotnet:2.0-sdk AS build

# copy everything else and build app
COPY . ./opt/app
WORKDIR /opt/app
RUN dotnet restore
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"


FROM microsoft/dotnet:2.0-runtime AS runtime
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build /opt/app/out ./
ENTRYPOINT ["dotnet", "AccountingPlanner.dll"]