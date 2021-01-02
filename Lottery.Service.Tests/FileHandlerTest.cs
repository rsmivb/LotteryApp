using Lottery.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Xunit;

namespace Lottery.Service.Tests
{
    public class FileHandlerServiceTest
    {
        private readonly FileHandlerService _fileHandler;

        public FileHandlerServiceTest()
        {
            var mockLogger = new Mock<ILogger<FileHandlerService>>();
            _fileHandler = new FileHandlerService(mockLogger.Object);
        }

        [Fact(DisplayName="Create and delete folder")]
        [Trait("FileHandler", "Service")]
        public void CreateAndDeleteFolder_Test()
        {
            var folderPath = @"C:\TempFolderTest";
            _fileHandler.CreateFolder(folderPath);
            Assert.True(Directory.Exists(folderPath));
            _fileHandler.CleanUpFolder(folderPath);
            Assert.False(Directory.Exists(folderPath));
        }

        [Fact(DisplayName = "Create file from a stream")]
        [Trait("FileHandler", "Service")]
        public void CreateFileFromStream_Test()
        {
            var expected = "response content";
            var folderTest = @"C:\TempFolderTest";
            var fileToBeTested = Path.Combine(folderTest, "Test.txt");
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            _fileHandler.CreateFolder(folderTest);
            _fileHandler.CreateFileFromStream(fileToBeTested, responseStream);

            string valueLoaded;
            using (var streamReader = new StreamReader(fileToBeTested))
            {
                valueLoaded = streamReader.ReadToEnd();
            }
            Assert.Equal(expected, valueLoaded);

            _fileHandler.CleanUpFolder(folderTest);

            Assert.False(File.Exists(fileToBeTested));
        }

        [Fact(DisplayName = "Create file from stream throwing exception")]
        [Trait("FileHandler", "Service")]
        public void CreateFileFromStream_ThrowsException_Test()
        {
            var folderTest = @"C:\TempFolderTest";
            var testPath = string.Empty;

            Assert.Throws<ArgumentException>(() => _fileHandler.CreateFileFromStream(testPath, new MemoryStream()));

            testPath = Path.Combine(folderTest, "test.txt");
            _fileHandler.CreateFolder(folderTest);
            Assert.Throws<NullReferenceException>(() => _fileHandler.CreateFileFromStream(testPath, null));
            _fileHandler.CleanUpFolder(folderTest);
            Assert.False(File.Exists(testPath));
        }

        [Fact(DisplayName = "UnZip file to folder")]
        [Trait("FileHandler", "Service")]
        public void UnZipFolder_Test()
        {
            var expectedZipFile = @"C:\TempFolderTest\testZip.zip";
            var expectedFile = @"C:\TempFolderTest\ZipFileTest\Test.txt";

            var zipFile = $@"C:\TempFolderTest\testZip.zip";
            var folderToZip = $@"C:\TempFolderTest\ZipFileTest\";
            var folderPath = $@"C:\TempFolderTest";
            _fileHandler.CreateFolder(folderToZip);
            CreateZipTestFile();
            Assert.True(File.Exists(expectedZipFile));

            _fileHandler.ExtractFile(zipFile, folderToZip);
            Assert.True(File.Exists(expectedFile));

            _fileHandler.CleanUpFolder(folderPath);
            Assert.False(Directory.Exists(folderPath));
        }

        private void CreateZipTestFile()
        {
            var folderToZip = $@"C:\TempFolderTest\ZipFileTest\";
            var zipFileTest = $@"C:\TempFolderTest\ZipFileTest\Test.txt";
            var zipFile = $@"C:\TempFolderTest\testZip.zip";
            //create file
            _fileHandler.CreateFolder(folderToZip);
            using (FileStream fs = File.Create(zipFileTest))
            {
                // Add some text to file
                byte[] title = new UTF8Encoding(true).GetBytes("Test creating a file");
                fs.Write(title, 0, title.Length);
            }

            //zip file created
            using (ZipArchive zipArchive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                DirectoryInfo di = new DirectoryInfo(folderToZip);
                FileInfo[] filesToArchive = di.GetFiles();

                if (filesToArchive != null && filesToArchive.Length > 0)
                {
                    foreach (FileInfo fileToArchive in filesToArchive)
                    {
                        zipArchive.CreateEntryFromFile(fileToArchive.FullName, fileToArchive.Name, CompressionLevel.Optimal);
                    }
                }
            }
            Directory.Delete(folderToZip, true);
        }
    }
}
