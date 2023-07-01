#Get based SDK Image from Microsof
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app

#Copy the CSPROJ file and restore any dependecies (via Nuget)
COPY *.csproj ./
RUN dotnet restore

#Copy the project files and build our realese
COPY . ./
RUN dotnet publish -c Release -o out

#Geterate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet","PlatformService.dll" ]