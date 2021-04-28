using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Logic
{
    public static class DirectoryHelper
    {
        public static void CleanDirectory(string directoryPath, params string[] directoriesToIgnore)
        {
            var dir = new DirectoryInfo(directoryPath);

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Директоия не найдена или она не существует: " + directoryPath);

            foreach (var file in dir.GetFiles())
            {
                File.Delete(file.FullName);
            }

            foreach (var subDir in dir.GetDirectories())
            {
                if (directoriesToIgnore.Contains(subDir.Name))
                    continue;

                Directory.Delete(subDir.FullName, true);
            }
        }

        public static void CopyDirectory(string sourceDirName, string destDirName, params string[] directoriesToIgnore)
        {
            var sourceDir = new DirectoryInfo(sourceDirName);

            if (!sourceDir.Exists)
                throw new DirectoryNotFoundException("Директоия не найдена или она не существует: " + sourceDirName);

            var sourceSubDirs = sourceDir.GetDirectories();

            Directory.CreateDirectory(destDirName);

            var files = sourceDir.GetFiles();
            foreach (var file in files)
            {
                var tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            foreach (var subDir in sourceSubDirs)
            {
                if (directoriesToIgnore.Contains(subDir.Name))
                    continue;

                var tempPath = Path.Combine(destDirName, subDir.Name);
                CopyDirectory(subDir.FullName, tempPath, directoriesToIgnore);
            }
        }
    }
}
