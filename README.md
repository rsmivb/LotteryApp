
## Latest Builds
Build    | Analyzers     | Quality Gate
-------- | :------------:| :------------: 
[![Build status](https://ci.appveyor.com/api/projects/status/q72alxqar06ublbe?svg=true)](https://ci.appveyor.com/project/rsmivb/lotteryapp) | [![codecov](https://codecov.io/gh/rsmivb/LotteryApp/branch/master/graph/badge.svg)](https://codecov.io/gh/rsmivb/LotteryApp) | [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=rsmivb_LotteryApp&metric=alert_status)](https://sonarcloud.io/dashboard?id=rsmivb_LotteryApp)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=rsmivb_LotteryApp&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=rsmivb_LotteryApp)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=rsmivb_LotteryApp&metric=security_rating)](https://sonarcloud.io/dashboard?id=rsmivb_LotteryApp)

# LotteryApp
Application for consuming Brazil official Lottery data and calculated some statistics for each lottery

##Using OpenCover coverage
As this is not working well with .net core, it is needed to change pdb files on csproj then OpenCover could be able to read pdb files as you can read here: https://medium.com/@sebastianfischer_69809/appveyor-travis-ci-and-a-net-core-application-acd2352f49dc and https://stackoverflow.com/questions/46890386/opencover-coverage-with-asp-net-core-2-0
