using Lottery.Models;
using Lottery.Models.Lotteries;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Lottery.Repository;
using System.Linq;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class LotteryServiceTest
    {
        //private readonly string content;
        //private readonly List<List<string>> returnListOfListOfStrings;
        //private readonly AppSettings appSettings;
        //private readonly Mock<IHtmlHandlerService> _mockHtmlService;
        //private readonly LotteryService _lotteryService;

        private readonly Mock<ILogger<ILotteryService>> _logger;
        private readonly ILotteryService _service;

        public LotteryServiceTest()
        {
            _logger = new Mock<ILogger<ILotteryService>>();
            _service = new LotteryService(_logger.Object);
        }

        [TestMethod]
        //https://stackoverflow.com/questions/30888325/cannot-convert-type-via-a-reference-conversion-boxing-conversion-unboxing-conv
        public void Test()
        {
            var megaSenaList = new List<MegaSena>
                {
                    new MegaSena
                    {
                        _id = new ObjectId("000000000000000000000000"),
                        LotteryId = 2146,
                        DateRealized = new DateTime(2019,4,27),
                        Dozens = new List<int> { 16, 18, 31, 39, 42, 44 },
                        TotalCollection = 150176040.00M,
                        Winners6Numbers = 0,
                        Average6Numbers = 0M,
                        Winners5Numbers = 283,
                        Average5Numbers = 30594.81M,
                        Winners4Numbers = 15338,
                        Average4Numbers = 806.43M,
                        IsAccumulated = true,
                        AccumulatedPrize = 107627872.22M,
                        EstimatedPrize = 125000000.00M,
                        AccumulatedMegaSenaVirada = 26248210.83M
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "MegaSena"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "MegaSena",
                Entries = megaSenaList.Cast<MongoModel>().ToList()
            };
            List<List<string>> list = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(list, lotteryData);

            Assert.AreEqual(expectedLotteryData, result);
        }
        //[TestMethod]
        //public void Test()
        //{
        //    //has lottery data
        //    var lotteryData = new LotteryData { Name = "MegaSena" };

        //    Type t = Type.GetType("Lottery.Service.Tests.MegaSenaExtensionMethods");
        //    object[] args = { lotteryData };
        //    IEnumerable<MegaSena> values = ((IEnumerable<MegaSena>)t.GetMethod("Load", BindingFlags.Static | BindingFlags.Public)
        //             .Invoke(null, args));
        //    foreach (var item in values)
        //    {
        //        Console.WriteLine(item.UF);
        //    }
        //    //var values = ((IEnumerable<MegaSena>)method.Invoke(null, new object[] { lotteryData })).GetEnumerator();

        //}
        //public LotteryServiceTest()
        //{
        //    content = @"<html>
        //            <head>
        //            <title>Resultado da Mega-sena</title>
        //            <STYLE>
        //            TD {
        //            FONT-FAMILY: Arial;
        //            FONT-SIZE: 10pt;
        //            HEIGHT: 15pt;
        //            TEXT-ALIGN: center
        //            }
        //            </STYLE>
        //            </head>
        //            <body>
        //            <p><strong><big><big><font face=""Arial"" color=""#004080"">Resultado da Mega-sena</font></big></big></strong></p>
        //            <p><img src=""t2.gif"">
        //            </p>
        //            <table border=""0"" cellspacing=""1"" cellpadding=""0"" width=""1810"">
        //            <tr>
        //            <th width=""50""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Concurso</font></small></th>
        //            <th width=""100"" height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Data Sorteio</font></small></th>
        //            <th width=""80""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">1ª Dezena</font></small></th>
        //            <th width=""80""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">2ª Dezena</font></small></th>
        //            <th width=""80""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">3ª Dezena</font></small></th>
        //            <th width=""80""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">4ª Dezena</font></small></th>
        //            <th width=""80""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">5ª Dezena</font></small></th>
        //            <th width=""80""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">6ª Dezena</font></small></th>
        //            <th width=""120""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Arrecadacao_Total</font></small></th>
        //            <th width=""95"" height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Ganhadores_Sena</font></small></th>
        //            <th width=""95"" height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Cidade</font></small></th>
        //            <th width=""95"" height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">UF</font></small></th>
        //            <th width=""120""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Rateio_Sena</font></small></th>
        //            <th width=""131"" height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Ganhadores_Quina</font></small></th>
        //            <th width=""120""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Rateio_Quina</font></small></th>
        //            <th width=""131""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Ganhadores_Quadra</font></small></th>
        //            <th width=""120""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Rateio_Quadra</font></small></th>
        //            <th width=""70""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Acumulado</font></small></th>
        //            <th width=""120""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Valor_Acumulado</font></small></th>
        //            <th width=""120""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Estimativa_Prêmio</font></small></th>
        //            <th width=""120""  height=""20"" bgcolor=""#7BA8D9""><small><font face=""Arial"" color=""#FFFFFF"">Acumulado_Mega_da_Virada</font></small></th>
        //            </tr>
        //            <tr>
        //            <td rowspan=""1"">1</td>
        //            <td rowspan=""1"">11/03/1996</td>
        //            <td rowspan=""1"">41</td>
        //            <td rowspan=""1"">05</td>
        //            <td rowspan=""1"">04</td>
        //            <td rowspan=""1"">52</td>
        //            <td rowspan=""1"">30</td>
        //            <td rowspan=""1"">33</td>
        //            <td rowspan=""1"">0,00</td>
        //            <td rowspan=""1"">0</td>
        //            <td rowspan=""1"">&nbsp</td><td rowspan=""1"">&nbsp</td>
        //            <td rowspan=""1"">0,00</td>
        //            <td rowspan=""1"">17</td>
        //            <td rowspan=""1"">39.158,92</td>
        //            <td rowspan=""1"">2016</td>
        //            <td rowspan=""1"">330,21</td>
        //            <td rowspan=""1"">SIM</td>
        //            <td rowspan=""1"">1.714.650,23</td>
        //            <td rowspan=""1"">0,00</td>
        //            <td rowspan=""1"">0,00</td>
        //            </tr>
        //            </table>
        //            </body>
        //            </html>";
        //    returnListOfListOfStrings = new List<List<string>>
        //    {
        //        new List<string>
        //        {
        //            "2146",
        //            "27/04/2019",
        //            "39",
        //            "42",
        //            "16",
        //            "18",
        //            "44",
        //            "31",
        //            "150.176.040,00",
        //            "0",
        //            "&nbsp",
        //            "&nbsp",
        //            "0,00",
        //            "283",
        //            "30.594,81",
        //            "15338",
        //            "806,43",
        //            "SIM",
        //            "107.627.872,22",
        //            "125.000.000,00",
        //            "26.248.210,83"
        //        }
        //    };
        //    appSettings = new AppSettings
        //    {
        //        TempFilePath = @"/../../../",
        //        DefaultURL = "http://www.dummy.com",
        //        Database = new Database
        //        {
        //            Name = string.Empty,
        //            Url = string.Empty
        //        },
        //        Lotteries = new List<LotterySetting>
        //        {
        //            new LotterySetting
        //            {
        //                Columns = 21,
        //                HtmlFileName = "anyFile.htm",
        //                Name = "MegaSena",
        //                WebFileName = string.Empty
        //            },
        //            new LotterySetting
        //            {
        //                Columns = 0,
        //                HtmlFileName = "error.txt",
        //                Name = "DuplaSena",
        //                WebFileName = string.Empty
        //            }
        //        }
        //    };
        //    _mockLogger = new Mock<ILogger<ILotteryService>>();
        //    _mockHtmlService = new Mock<IHtmlHandlerService>();
        //    _lotteryService = new LotteryService(_mockHtmlService.Object, appSettings, _mockLogger.Object);
        //}

        //[TestMethod("Choose lottery based on listOfStrings")]
        //[TestCategory("LotteryService")]
        //public void ChooseLottery_Test()
        //{
        //    var listOfStrings = new List<List<string>>();
        //    var lotteryName = "MegaSena";
        //    var returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<MongoModel>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<DuplaSena>));

        //    lotteryName = "DuplaSena";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<DuplaSena>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));

        //    lotteryName = "Federal";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<Federal>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));

        //    lotteryName = "Loteca";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<Loteca>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));

        //    lotteryName = "LotoFacil";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<LotoFacil>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));

        //    lotteryName = "LotoGol";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<LotoGol>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));

        //    lotteryName = "LotoMania";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<LotoMania>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));

        //    lotteryName = "Quina";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<Quina>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));

        //    lotteryName = "TimeMania";
        //    returnedListOfValues = _lotteryService.ChooseLottery(listOfStrings, lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<TimeMania>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));
        //}

        //[TestMethod("Choose lottery based on listOfStrings and it throws an Exception")]
        //[TestCategory("LotteryService")]
        //public void ChooseLottery_ReturnsThrowException_Test()
        //{
        //    var lotteryName = "Not Exists";
        //    var expectedExceptionMessage = $"Lottery {lotteryName} did not support.";
        //    NotSupportedException ex = Assert.ThrowsException<NotSupportedException>(() => _lotteryService.ChooseLottery(new List<List<string>>(), lotteryName));
        //    Assert.AreEqual(expectedExceptionMessage, ex.Message);
        //}

        //[TestMethod("Load lottery")]
        //[TestCategory("LotteryService")]
        //public void LoadLottery_Test()
        //{
        //    var lotteryName = "MegaSena";
        //    var path = Path.Combine(Environment.CurrentDirectory, $@"../../../{lotteryName}/");
        //    var fileName = "anyFile.htm";
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    var filePath = Path.Combine(path, fileName);
        //    if (!File.Exists(filePath))
        //    {
        //        using (FileStream fs = File.Create(filePath))
        //        {
        //            // Add some text to file
        //            var title = new UTF8Encoding(true).GetBytes(content);
        //            fs.Write(title, 0, title.Length);
        //        }
        //    }
        //    Assert.IsTrue(File.Exists(filePath));
        //    _mockHtmlService.SetReturnsDefault(returnListOfListOfStrings);
        //    var returnedListOfValues = _lotteryService.Load(lotteryName);
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<MegaSena>));
        //    Assert.IsInstanceOfType(returnedListOfValues, typeof(IEnumerable<MongoModel>));
        //    Assert.IsNotInstanceOfType(returnedListOfValues, typeof(IEnumerable<DuplaSena>));

        //    Directory.Delete(path, true);
        //    Assert.IsFalse(Directory.Exists(path));
        //}

        //[TestMethod("Load lottery throws an FileNotFoundExceptio")]
        //[TestCategory("LotteryService")]
        //public void LoadLottery_Throws_FileNotFoundException_Test()
        //{
        //    var lotteryName = "DuplaSena";
        //    var pathError = $@"{Environment.CurrentDirectory}/{lotteryName}/error.txt";
        //    var expectedErrorMessage = $"The lottery file on path {pathError} does not exist, please check AppSetting object.";
        //    Assert.ThrowsException<FileNotFoundException>(() => _lotteryService.Load(lotteryName));
        //}

        //[TestMethod("Load lottery throws an EntryPointNotFoundException")]
        //[TestCategory("LotteryService")]
        //public void LoadLottery_Throws_EntryPointNotFoundException_Test()
        //{
        //    var lotteryName = "Lottery_Doesn't_Exist";
        //    Assert.ThrowsException<EntryPointNotFoundException>(() => _lotteryService.Load(lotteryName));
        //}
    }
}
