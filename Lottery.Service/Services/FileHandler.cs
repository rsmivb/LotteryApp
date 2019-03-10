using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Services
{
    public class FileHandler : IFileHandler
    {
        public void ExtractFile(string zipPath, string tempFile)
        {
            try
            {
                CleanUpFolder(tempFile);
                ZipFile.ExtractToDirectory(zipPath, tempFile);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void CleanUpFolder(string path)
        {
            try
            {
                if (Directory.Exists(path)) Directory.Delete(path, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CreateFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
