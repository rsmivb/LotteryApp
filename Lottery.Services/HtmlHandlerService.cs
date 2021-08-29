using HtmlAgilityPack;
using Lottery.Models.Lotteries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Services
{
    public class HtmlHandlerService : IHtmlHandlerService
    {
        private readonly ILogger<IHtmlHandlerService> _logger;

        public HtmlHandlerService(ILogger<IHtmlHandlerService> logger)
        {
            _logger = logger;
        }
        public List<List<string>> ConvertHtmlTo(LotteryData lottery)
        {
            try
            {
                var doc = new HtmlDocument();
                doc.Load(lottery.HtmlFilePath, Encoding.UTF8);
                _logger.LogDebug("Trying to load stream.");
                if (doc.DocumentNode?.ChildNodes?.Count < 1)
                {
                    throw new HtmlWebException("HTML file is empty.");
                }

                var trs = doc.DocumentNode.SelectNodes("//tr").Skip(1);

                List<List<string>> lines = new List<List<string>>();
                List<string> nodes = new List<string>();
                foreach (var tr in trs)
                {
                    foreach (var td in tr.ChildNodes)
                    {
                        // Loteca !td.InnerText.Equals("\n\t")
                        // MegaSena !td.InnerText.StartWith("\n   ") && InnerHtml.StartWith("<!-- DEZENAS -->") Ler até rateio Faixa3
                        if (!td.InnerText.StartsWith("\n") && !td.InnerHtml.StartsWith("<!--"))
                        {
                            nodes.Add(td.InnerText.Trim());
                        }
                    }
                    if (nodes.Count == lottery.Columns)
                    {
                        lines.Add(nodes);
                    }
                    nodes = new List<string>();
                }
                _logger.LogDebug($"Loaded all lines on HTML file -> {lines.Count} lines");
                return lines;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error was found. Error: {e.Message} - {e.StackTrace}");
                throw;
            }
        }
    }
}
