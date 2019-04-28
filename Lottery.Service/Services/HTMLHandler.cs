using HtmlAgilityPack;
using Lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services
{
    public class HTMLHandler
    {

        /// <summary>
        /// NEED to Improve loading data for a specific Lottery, maybe pass class name and generate it.
        /// Or maybe create a specific method for each lottery class
        /// </summary>
        public IEnumerable<MongoModel> LoadHTMLFile(string path, LotterySetting lotterySettings)
        {
            try
            {
                var doc = new HtmlDocument();
                doc.Load(path);
                if (doc != null)
                {
                    var trs = doc.DocumentNode.SelectNodes("//tr").Skip(1); //Skip headers on table

                    IList<IList<string>> lines = new List<IList<string>>();
                    IList<string> nodes = new List<string>();
                    foreach (var tr in trs)
                    {
                        foreach (var td in tr.ChildNodes)
                        {
                            if (!td.InnerText.Equals("\r\r\n") &&
                                !td.InnerText.Equals("\r\n") &&
                                !td.InnerText.Equals("\r"))
                            {
                                nodes.Add(td.InnerText.Trim());
                            }
                        }
                        if (nodes.Count == lotterySettings.Columns)
                        {
                            lines.Add(nodes);
                        }
                        else
                        {
                            Console.WriteLine(nodes.Count);
                        }
                        nodes = new List<string>();
                    }
                    //Load to objects
                    return LoadToLottery(lines, lotterySettings.Name);
                }
                else
                {
                    throw new Exception("HTML file is empty.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<MongoModel> LoadToLottery(IList<IList<string>> lines, string lotteryName)
        {
            IEnumerable<MongoModel> results = new List<MongoModel>();
            switch (lotteryName)
            {
                case "DuplaSena":
                    results = DuplaSenaExtensionMethods.Load(lines);
                    break;
                case "Federal":
                    results = FederalExtensionMethods.Load(lines);
                    break;
                case "TimeMania":
                    results = TimeManiaExtensionMethods.Load(lines);
                    break;
                case "Quina":
                    results = QuinaExtensionMethods.Load(lines);
                    break;
                case "LotoMania":
                    results = LotoManiaExtensionMethods.Load(lines);
                    break;
                case "LotoGol":
                    results = LotoGolExtensionMethods.Load(lines);
                    break;
                case "LotoFacil":
                    results = LotoFacilExtensionMethods.Load(lines);
                    break;
                case "Loteca":
                    results = LotecaExtensionMethods.Load(lines);
                    break;
                case "MegaSena":
                    results = MegaSenaExtensionMethods.Load(lines);
                    break;
                default:
                    throw new NotSupportedException($"Lottery {lotteryName} did not support.");
            }
            return results;
        }
    }
}
