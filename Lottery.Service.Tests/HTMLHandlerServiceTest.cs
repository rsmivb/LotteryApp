using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class HTMLHandlerServiceTest
    {
        private string _htmlContent;
        private Mock<ILogger<HTMLHandlerService>> _mockLogger;
        private HTMLHandlerService _service;

        [TestInitialize]
        public void Setup()
        {
            _htmlContent = @"<html>
                                <head>
                                <title>Resultado do Timemania</title>
                                <STYLE>
                                TD {
                                FONT-FAMILY: Arial;
                                FONT-SIZE: 10pt;
                                HEIGHT: 15pt;
                                TEXT-ALIGN: center
                                }
                                </STYLE>
                                </head>
                                <body bgcolor=""#FFFFFF"">
                                <p><strong><big><big><font face=""Arial"" color=""#004080"">Resultado do Timemania</font></big></big></strong></p>
                                <p><img src=""t12.gif"">
                                </p>
                                <table border=""0"" cellspacing=""1"" cellpadding=""0"" width=""4600"">
                                <tr>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Concurso</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Data Sorteio</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Bola1</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Bola2</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Bola3</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Bola4</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Bola5</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Bola6</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Bola7</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Time_Coração</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Arrecadado</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Ganhadores_7_Números</font></small></th>
                                <th width=""95"" height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Cidade</font></small></th>
                                <th width=""95"" height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">UF</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Ganhadores_6_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Ganhadores_5_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Ganhadores_4_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Ganhadores_3_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Ganhadores_Time_Coração</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Rateio_7_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Rateio_6_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Rateio_5_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Rateio_4_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Rateio_3_Números</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Time_Coração</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Valor_Acumulado</font></small></th>
                                <th height=""20"" bgcolor=""#00923F""><small><font face=""Arial"" color=""#FFF500"">Estimativa_Premio</font></small></th>
                                </tr>
                                <tr>
                                <td rowspan=""1"">1</td>
                                <td rowspan=""1"">01/03/2008</td>
                                <td rowspan=""1"">71</td>
                                <td rowspan=""1"">51</td>
                                <td rowspan=""1"">63</td>
                                <td rowspan=""1"">57</td>
                                <td rowspan=""1"">24</td>
                                <td rowspan=""1"">80</td>
                                <td rowspan=""1"">31</td>
                                <td rowspan=""1"">PALMAS/TO</td>
                                <td rowspan=""1"">0,00</td>
                                <td rowspan=""1"">0</td>
                                <td rowspan=""1"">&nbsp</td><td rowspan=""1"">&nbsp</td>
                                <td rowspan=""1"">6</td>
                                <td rowspan=""1"">328</td>
                                <td rowspan=""1"">6032</td>
                                <td rowspan=""1"">60403</td>
                                <td rowspan=""1"">13122</td>
                                <td rowspan=""1"">0,00</td>
                                <td rowspan=""1"">59.909,90</td>
                                <td rowspan=""1"">730,61</td>
                                <td rowspan=""1"">6,00</td>
                                <td rowspan=""1"">2,00</td>
                                <td rowspan=""1"">2,00</td>
                                <td rowspan=""1"">479.279,20</td>
                                <td rowspan=""1"">1.000.000,00</td>
                                </tr>
                                <tr bgcolor=#B9E1CA>
                                <td rowspan=""1"">2</td>
                                <td rowspan=""1"">08/03/2008</td>
                                <td rowspan=""1"">77</td>
                                <td rowspan=""1"">18</td>
                                <td rowspan=""1"">31</td>
                                <td rowspan=""1"">25</td>
                                <td rowspan=""1"">20</td>
                                <td rowspan=""1"">63</td>
                                <td rowspan=""1"">50</td>
                                <td rowspan=""1"">SÃO PAULO/SP</td>
                                <td rowspan=""1"">0,00</td>
                                <td rowspan=""1"">0</td>
                                <td rowspan=""1"">&nbsp</td><td rowspan=""1"">&nbsp</td>
                                <td rowspan=""1"">10</td>
                                <td rowspan=""1"">316</td>
                                <td rowspan=""1"">5882</td>
                                <td rowspan=""1"">58525</td>
                                <td rowspan=""1"">104390</td>
                                <td rowspan=""1"">0,00</td>
                                <td rowspan=""1"">28.097,91</td>
                                <td rowspan=""1"">592,79</td>
                                <td rowspan=""1"">6,00</td>
                                <td rowspan=""1"">2,00</td>
                                <td rowspan=""1"">2,00</td>
                                <td rowspan=""1"">853.917,98</td>
                                <td rowspan=""1"">1.200.000,00</td>
                                </tr>
                                </table>
                                </body>
                                </html>
                                ";
            _mockLogger = new Mock<ILogger<HTMLHandlerService>>();
            _service = new HTMLHandlerService(_mockLogger.Object);

        }

        [TestMethod]
        public void LoadHTMLFile_Test()
        {
            // Arrange
            var expectedListString = new List<List<string>>
            {
                new List<string>
                {
                    "1","01/03/2008","71","51","63","57","24","80","31","PALMAS/TO","0,00","0","&nbsp","6","328","6032","60403","13122","0,00","59.909,90","730,61","6,00","2,00","2,00","479.279,20","1.000.000,00"
                },
                new List<string>
                {
                    "2","08/03/2008","77","18","31","25","20","63","50","SÃO PAULO/SP","0,00","0","&nbsp","10","316","5882","58525","104390","0,00","28.097,91","592,79","6,00","2,00","2,00","853.917,98","1.200.000,00"
                }
            };
            List<List<string>> result = new List<List<string>>();
            // Act
            result = _service.LoadHTMLFile(_htmlContent.ToStream(), 26);
            // Assert
            CollectionAssert.Equals(expectedListString, result);
        }
    }

    public static class StreamGenerationTest
    {
        public static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
