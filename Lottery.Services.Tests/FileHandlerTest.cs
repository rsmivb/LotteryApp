using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Text;


namespace Lottery.Service.Tests
{
    [TestClass]
    public class FileHandlerServiceTest
    {
        private readonly FileHandlerService _fileHandler;

        public FileHandlerServiceTest()
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
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            _fileHandler.CreateFileFromStream(fileToBeTested, responseStream);

            string valueLoaded;
            using (var streamReader = new StreamReader(fileToBeTested))
            {
                valueLoaded = streamReader.ReadToEnd();
            }
            Assert.AreEqual(expected, valueLoaded);

            _fileHandler.CleanUpFolder(folderTest);

            Assert.IsFalse(File.Exists(fileToBeTested));
        }

        [TestMethod("Create file from stream throwing exception")]
        [TestCategory("FileHandlerService")]
        public void CreateFileFromStream_ThrowsException_Test()
        {
            var folderTest = @"C:\TempFolderTest";
            var testPath = string.Empty;
            Assert.ThrowsException<ArgumentException>(() => _fileHandler.CreateFileFromStream(testPath, new MemoryStream()));
        }

        [TestMethod("UnZip file to folder")]
        [TestCategory("FileHandlerService")]
        public void UnZipFolder_Test()
        {
            var folderToUnzip = $"{Environment.CurrentDirectory}/Resources/Test/";
            var zipFile = $"{Environment.CurrentDirectory}/Resources/Test.zip";
            var expectedFile = $"{Environment.CurrentDirectory}/Resources/Test/somefile.txt";

            _fileHandler.ExtractFile(zipFile, folderToUnzip);
            Assert.IsTrue(File.Exists(expectedFile));

            _fileHandler.CleanUpFolder(folderToUnzip);
            Assert.IsFalse(Directory.Exists(folderToUnzip));
        }
    }
}
