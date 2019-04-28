Test project to show the benefits of using events and delegates to get decoupled code

### How to build and run using `dotnet cli`
```
dotnet build src/VideoEncoder -c Release
dotnet run -p src/VideoEncoder -c Release Test
``` 

### How to build and test using `dotnet cli`
```
dotnet build tests/VideoEncoder.Tests -c Release
dotnet test --no-build tests/VideoEncoder.Tests -c Release
``` 

### How to build and run using `docker cli`
```
# build image and tag it
docker build -t video-encoder-dev .
# run image using tag ^^
docker run --rm -it video-encoder-dev test-docker
```
