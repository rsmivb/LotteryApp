using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lottery.Models.Test
{
    [TestClass]
    public class ExtensionsMethodsTest
    {
        [TestMethod]
        public void ConvertEmptyToString_Test()
        {
            string expected = string.Empty;
            string toBeTested = "&nbsp";
            var result = toBeTested.ConvertEmptyToString();
            Assert.AreEqual(expected, result);
            toBeTested = "   ";
            result = toBeTested.ConvertEmptyToString();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ConvertWithMetaChatToString_Test()
        {
            string expected = string.Empty;
            string toBeTested = "&nbsp";
            var result = toBeTested.ConvertWithMetaChatToString();
            Assert.AreEqual(expected, result);
            toBeTested = "\r";
            result = toBeTested.ConvertEmptyToString();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ConvertToDecimal_Test()
        {
            decimal expected = 0;
            string toBeTested = "";
            var result = toBeTested.ConvertToDecimal();
            Assert.AreEqual(expected, result);
            expected = 2.0m;
            toBeTested = "2,0";
            result = toBeTested.ConvertToDecimal();
            Assert.AreEqual(expected, result);
            expected = 0;
            toBeTested = "-";
            result = toBeTested.ConvertToDecimal();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ConvertToDateTime_Test()
        {
            DateTime expected = new DateTime(1996, 03, 11);
            string toBeTested = "11/03/1996";
            var result = toBeTested.ConvertToDateTime();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ConvertToInt_Test()
        {
            int expected = 0;
            string toBeTested = "     ";
            var result = toBeTested.ConvertToInt();
            Assert.AreEqual(expected, result);
            expected = 1;
            toBeTested = "1";
            result = toBeTested.ConvertToInt();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ConvertToBoolean_Test()
        {
            bool expected = true;
            string toBeTested = "SIM";
            var result = toBeTested.ConvertToBoolean();
            Assert.AreEqual(expected, result);
            expected = false;
            toBeTested = "S";
            result = toBeTested.ConvertToBoolean();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ConvertToChar_Test()
        {
            char expected = '1';
            string toBeTested = "1";
            var result = toBeTested.ConvertToChar();
            Assert.AreEqual(expected, result);
            expected = 'x';
            toBeTested = "x";
            result = toBeTested.ConvertToChar();
            Assert.AreEqual(expected, result);
        }

    }
}
