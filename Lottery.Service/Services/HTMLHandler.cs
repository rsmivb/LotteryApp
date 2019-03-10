using HtmlAgilityPack;
using Lottery.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Services
{
    public enum LotteryTypeColumn
    {
        MegaSena = 21,
        DuplaSena = 0,
        Federal = 0,
        Loteca = 0,
        LotoFacil = 0,
        LotoGol = 0,
        LotoMania = 0,
        Quina = 0,
        TimeMania = 0
    }
    public class HTMLHandler
    {

        /// <summary>
        /// NEED to Improve loading data for a specific Lottery, maybe pass class name and generate it.
        /// Or maybe create a specific method for each lottery class
        /// </summary>
        public void LoadHTMLFile(string path)
        {
            //string file = string.Concat(_tempFile, _htmlFileName);
            var doc = new HtmlDocument();
            doc.Load(path);//file);
            if (doc != null)
            {
                var trs = doc.DocumentNode.SelectNodes("//tr").Skip(1); //Skip headers on table
                foreach (var row in trs)
                {
                    var results = row.ChildNodes.Where(td => !td.InnerText.Equals("\r\r\n") &&
                                                               !td.InnerText.Equals("\r\n") &&
                                                               !td.InnerText.Equals("\r"));
                }
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
                    if (nodes.Count == 21)
                    {

                    }
                    nodes = new List<string>();
                }
            }
        }
    }
}
