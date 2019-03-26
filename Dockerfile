FROM microsoft/dotnet:2.1-sdk
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./src/VideoEncoder/*.csproj ./
RUN dotnet restore

# copy and build everything else
COPY ./src/VideoEncoder ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/VideoEncoder.dll"]
