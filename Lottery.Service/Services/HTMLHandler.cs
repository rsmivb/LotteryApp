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
        private readonly string _tempFile;
        private readonly string _htmlFileName;
        private readonly Type _type;
        public HTMLHandler(string tempFile, string htmlFileName, Type type)
        {
            _tempFile = tempFile;
            _htmlFileName = htmlFileName;
            _type = type;
        }
        /// <summary>
        /// NEED to Improve loading data for a specific Lottery, maybe pass class name and generate it.
        /// Or maybe create a specific method for each lottery class
        /// </summary>
        public void ReadHTMLFile()
        {
            string file = string.Concat(_tempFile, _htmlFileName);

            var doc = new HtmlDocument();
            doc.Load(file);
            var trs = doc.DocumentNode.SelectNodes("//tr").Skip(1); //Skip headers on table
            IList<string> nodes = new List<string>();
            CultureInfo BrCulture = new CultureInfo("pt-BR");
            IList<MegaSena> allConcursos = new List<MegaSena>();
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
                    allConcursos.Add(null);
                }
                nodes = new List<string>();
            }

        }
    }
}
