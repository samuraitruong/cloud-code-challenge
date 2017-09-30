# .NET Core 2.0 Sample project

CI Build status: Travis CI [![Build Status](https://travis-ci.org/samuraitruong/cloud-code-challenge.svg?branch=master)](https://travis-ci.org/samuraitruong/cloud-code-challenge)
# prerequisites
To run source code on your local machine you ned
- git to clone source (of course) or use Download To Desktop
- [Visual Studio 2007 (Community is Ok)](https://www.visualstudio.com/downloads/)
- [.Net Core 2.0 SDK](https://www.microsoft.com/net/download/core)
- [.NET Core 2.0 CLI](https://www.microsoft.com/net/download/core)

# Build
The solution can be build and run directly from Visual Studio 2017 with support .net core 2.0

If you don't have visual studio 2017 install on machine, Solution can be built with .NET core CLI

`dotnet restore && dot build`

Read more about [.NET Core Build](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build?tabs=netcore2x#tabpanel_mTshLtg2eu_netcore2x)

# Run
This project is build base on .NET core 2.0 can be ran cross platform on window, Linux, Mac OS and any platform that support by .NET core CLI

after build , to to output folder of MVC project

`cd Hiring.Cloud.CodeChallenge/Hiring.Cloud.CodeChallenge.MVC/bin/Debug/netcoreapp2.0`
`dotnet Hiring.Cloud.CodeChallenge.MVC.dll`

# Environement configs
The configuration file is place at the configs folder, The file will pickup by global variable environment. 
for example , to run program with Production config, we can execute below command

`set ASPNETCORE_ENVIRONMENT=Development && dotnet Hiring.Cloud.CodeChallenge.MVC.dll`

#Test
The Test project is implemented with [XUnit](https://xunit.github.io) can be execute from source with Net Core CLI

`dotnet test Hiring.Cloud.CodeChallenge.Test/Hiring.Cloud.CodeChallenge.Test.csproj`

Test can also run wit compiled Test assembly
`dotnet test Hiring.Cloud.CodeChallenge.Test/bin/Debug/netcoreapp2.0/Hiring.Cloud.CodeChallenge.Test.dll`

# CI & Deploy

This project is pre-configure with (https://travis-ci.org "Travis CI").
When the build finish, Travis will deploy to azure website. Make sure you setup Azure Username, Password, and Sitename inside Travis Setting. Read more about [Travis Azure deployment](https://docs.travis-ci.com/user/deployment/azure-web-apps/)

This repository is deployed  at (http://cloudcodechallenge.azurewebsites.net)

The sample API can be access from (http://cloudcodechallenge.azurewebsites.net/api/cars)










