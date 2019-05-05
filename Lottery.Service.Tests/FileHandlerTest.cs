using Lottery.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class FileHandlerServiceTest
    {
        private FileHandlerService _fileHandler;
        private string _folderPath;
        private string _zipFileTest;
        private string _folderToZip;
        private string _zipFile;
        private string _zipFolder;

        [TestInitialize]
        public void Setup()
        {
            _fileHandler = new FileHandlerService();
            _folderPath = @"C:\TempFolderTest";
            _zipFileTest = $@"{_folderPath}\ZipFileTest\Test.txt";
            _folderToZip = $@"{_folderPath}\ZipFileTest\";
            _zipFile = $@"{_folderPath}\ZipFolderTest\testZip.zip";

        }
        [TestCategory("File Handler Service Test")]
        [TestMethod]
        public void CreateFolder_Test()
        {
            _fileHandler.CreateFolder(_folderPath);
            Assert.IsTrue(System.IO.Directory.Exists(_folderPath));

            _fileHandler.CleanUpFolder(_folderPath);
            Assert.IsFalse(System.IO.Directory.Exists(_folderPath));
        }
        [TestCategory("File Handler Service Test")]
        [TestMethod]
        public void UnZipFolder_Test()
        {
            var expectedZipFile = @"C:\TempFolderTest\ZipFolderTest\testZip.zip";
            _fileHandler.CreateFolder(@"C:\TempFolderTest\ZipFolderTest");
            CreateZipTestFile();
            Assert.IsTrue(System.IO.File.Exists(expectedZipFile));

            _fileHandler.ExtractFile(_zipFile, _folderPath);
            var expectedFile = @"C:\TempFolderTest\Test.txt";
            Assert.IsTrue(System.IO.File.Exists(expectedFile));

            _fileHandler.CleanUpFolder(_folderPath);
            Assert.IsFalse(System.IO.Directory.Exists(_folderPath));
        }
        private void CreateZipTestFile()
        {
            //create file
            _fileHandler.CreateFolder(_folderToZip);
            using (FileStream fs = File.Create(_zipFileTest))
            {
                // Add some text to file
                Byte[] title = new UTF8Encoding(true).GetBytes("Test creating a file");
                fs.Write(title, 0, title.Length);
            }

            //zip file created
            using (ZipArchive zipArchive = ZipFile.Open(_zipFile, ZipArchiveMode.Create))
            {
                DirectoryInfo di = new DirectoryInfo(_folderToZip);
                FileInfo[] filesToArchive = di.GetFiles();

                if (filesToArchive != null && filesToArchive.Length > 0)
                {
                    foreach (FileInfo fileToArchive in filesToArchive)
                    {
                        zipArchive.CreateEntryFromFile(fileToArchive.FullName, fileToArchive.Name, CompressionLevel.Optimal);
                    }
                }
            }
        }
    }
}
