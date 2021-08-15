using Lottery.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class GenericExtensionsMethodsTests
    {

        [TestMethod("Converts Special ANSI Chars and WhiteSpaces to an Empty String")]
        [TestCategory("GenericExtensionsMethods")]
        [DataRow("", "&nbsp")]
        [DataRow("", "    ")]
        public void ConvertEmptyToString_Test(string expected, string toBeTested)
        {
            var result = toBeTested.ConvertEmptyToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod("Converts Special ANSI and Meta Chars to an Empty String")]
        [TestCategory("GenericExtensionsMethods")]
        [DataRow("", "&nbsp")]
        [DataRow("", "\r")]
        public void ConvertWithMetaChatToString_Test(string expected, string toBeTested)
        {
            var result = toBeTested.ConvertWithMetaChatToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod("Converts dash,Portuguese number to a decimal")]
        [TestCategory("GenericExtensionsMethods")]
        [DataRow(0, "")]
        [DataRow(2.0, "2,0")]
        [DataRow(0, "-")]
        public void ConvertToDecimal_Test(double value, string toBeTested)
        {
            var result = toBeTested.ConvertToDecimal();
            var expected = Convert.ToDecimal(value);
            Assert.AreEqual(expected, result);
        }

        [TestMethod("Converts string value to a DateTime")]
        [TestCategory("GenericExtensionsMethods")]
        public void ConvertToDateTime_Test()
        {
            DateTime expected = new DateTime(1996, 03, 11);
            string toBeTested = "11/03/1996";
            var result = toBeTested.ConvertToDateTime();
            Assert.AreEqual(expected, result);
        }

        [TestMethod("Converts WhiteSpaces into a decimal")]
        [TestCategory("GenericExtensionsMethods")]
        [DataRow(0, "     ")]
        [DataRow(1, "1")]
        public void ConvertToInt_Test(int expected, string toBeTested)
        {
            var result = toBeTested.ConvertToInt();
            Assert.AreEqual(expected, result);
        }

        [TestMethod("Converts SIM to a boolean")]
        [TestCategory("GenericExtensionsMethods")]
        [DataRow(true, "SIM")]
        [DataRow(false, "S")]
        public void ConvertToBoolean_Test(bool expected, string toBeTested)
        {
            var result = toBeTested.ConvertToBoolean();
            Assert.AreEqual(expected, result);
        }
        [TestMethod("Converts string value to a DateTime to a first char")]
        [TestCategory("GenericExtensionsMethods")]
        [DataRow("1", "112")]
        [DataRow("x", "xasd")]
        public void ConvertToChar_Test(string expected, string toBeTested)
        {
            var result = toBeTested.ConvertToAChar();
            Assert.AreEqual(expected, result);
        }

        [TestMethod("Try Converts string value to a char but it throws an exception")]
        [TestCategory("GenericExtensionsMethods")]
        public void ConvertToCharException_Test()
        {
            var toBeTested = string.Empty;
            var expectedResult = string.Empty;
            var result = toBeTested.ConvertToAChar();
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod("Given a lottery name convert to a Type")]
        [TestCategory("GenericExtensionsMethods")]
        public void GivenLotteryNameConvertToType_Test()
        {
            var toBeTested = "MegaSena";
            var expectedResult = typeof(MegaSenaExtensionMethods);
            var result = toBeTested.ConvertToExtensionsMethodsType();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
