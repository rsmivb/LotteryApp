using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Lottery.Services
{
    public class HTMLHandlerService : IHTMLHandlerService
    {
        private ILogger<IHTMLHandlerService> _logger;

        public HTMLHandlerService(ILogger<IHTMLHandlerService> logger)
        {
            _logger = logger;
        }
        public List<List<string>> LoadHTMLFile(Stream streamFile, int columnLimit)
        {
            try
            {
                var doc = new HtmlDocument();
                doc.Load(streamFile, Encoding.UTF7);
                _logger.LogDebug("Trying to load stream.");
                if (doc != null)
                {
                    var trs = doc.DocumentNode.SelectNodes("//tr").Skip(1); //Skip headers on table

                    List<List<string>> lines = new List<List<string>>();
                    List<string> nodes = new List<string>();
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
                        if (nodes.Count == columnLimit)
                        {
                            lines.Add(nodes);
                        }
                        nodes = new List<string>();
                    }
                    _logger.LogDebug($"Loaded all lines on HTML file -> {lines.Count} lines");
                    return lines;
                }
                else
                {
                    _logger.LogError("Error reading HTML stream file.");
                    throw new Exception("HTML file is empty.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error was found. Error: {e.Message} - {e.StackTrace}");
                throw;
            }
        }
    }
}
