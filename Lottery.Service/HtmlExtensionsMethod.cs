using Lottery.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lottery.Service
{
    public static class HtmlExtensionsMethod
    {

        public static T LoadToLottery<T>(this IList<string> nodes, CultureInfo info, T type)
        {
            switch (type.GetType().Name)
            {
                case "DuplaSena": break;
                case "Federal": break;
                case "Loteca": break;
                case "LotoFacil": break;
                case "LotoGol": break;
                case "LotoMania": break;
                case "MegaSena": break;
                case "Quina": break;
                case "TimeMania": break;
            }
            throw new NotImplementedException();
        }
    }
}
