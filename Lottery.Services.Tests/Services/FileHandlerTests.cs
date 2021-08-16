using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Text;


namespace Lottery.Services.Tests
{
    [TestClass]
    public class FileHandlerServiceTests
    {
        private readonly FileHandlerService _fileHandler;

        public FileHandlerServiceTests()
        {
            var mockLogger = new Mock<ILogger<FileHandlerService>>();
            _fileHandler = new FileHandlerService(mockLogger.Object);
        }


        [TestMethod("Create file from a stream")]
        [TestCategory("FileHandlerService")]
        public void CreateFileFromStream_Test()
        {
            var expected = "response content";
            var folderTest = @"C:\TempFolderTest";
            var fileToBeTested = Path.Combine(folderTest, "Test.txt");

            _fileHandler.CreateFile(fileToBeTested, expected);

            var valueLoaded = File.ReadAllText(fileToBeTested);
            Assert.AreEqual(expected, valueLoaded);

            _fileHandler.CleanUpFolder(folderTest);

            Assert.IsFalse(File.Exists(fileToBeTested));
        }

        [TestMethod("Create file from stream throwing exception")]
        [TestCategory("FileHandlerService")]
        public void CreateFileFromStream_ThrowsException_Test()
        {
            var testPath = string.Empty;
            Assert.ThrowsException<ArgumentException>(() => _fileHandler.CreateFile(testPath, string.Empty));
        }
    }
}
