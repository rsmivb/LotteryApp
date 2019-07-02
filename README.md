
## Latest Builds
Build    | Analyzers     | Quality Gate    |   License
-------- | :------------:| :------------:  | :------------:
[![Build status](https://ci.appveyor.com/api/projects/status/q72alxqar06ublbe?svg=true)](https://ci.appveyor.com/project/rsmivb/lotteryapp)  [![Build Status](https://travis-ci.org/rsmivb/LotteryApp.svg?branch=master)](https://travis-ci.org/rsmivb/LotteryApp) | [![codecov](https://codecov.io/gh/rsmivb/LotteryApp/branch/master/graph/badge.svg)](https://codecov.io/gh/rsmivb/LotteryApp)  [![Coverage Status](https://coveralls.io/repos/github/rsmivb/LotteryApp/badge.svg?branch=master)](https://coveralls.io/github/rsmivb/LotteryApp?branch=master) | [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=rsmivb_LotteryApp&metric=alert_status)](https://sonarcloud.io/dashboard?id=rsmivb_LotteryApp) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=rsmivb_LotteryApp&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=rsmivb_LotteryApp) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=rsmivb_LotteryApp&metric=security_rating)](https://sonarcloud.io/dashboard?id=rsmivb_LotteryApp) | [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

# LotteryApp
Application for consuming Brazil official Lottery data and calculated some statistics for each lottery

##Using OpenCover coverage
As this is not working well with .net core, it is needed to change pdb files on csproj then OpenCover could be able to read pdb files as you can read here: https://medium.com/@sebastianfischer_69809/appveyor-travis-ci-and-a-net-core-application-acd2352f49dc and https://stackoverflow.com/questions/46890386/opencover-coverage-with-asp-net-core-2-0

# How to use CICD tools for open source projects

Builds
https://www.appveyor.com/docs/
https://docs.travis-ci.com/user/tutorial/

Test code coverage
https://codecov.io
https://docs.coveralls.io/

Scan code Quality 
https://sonarcloud.io/documentation/
