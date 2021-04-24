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
        private static readonly string _backUpFolderName = ConfigurationManager.AppSettings["backUpFolderName"];

        public static void CleanDirectory(string directoryPath)
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
                if (subDir.FullName.Contains(_backUpFolderName))
                    continue;

                Directory.Delete(subDir.FullName, true);
            }
        }

        public static void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Директоия не найдена или она не существует: " + sourceDirName);

            var dirs = dir.GetDirectories();

            Directory.CreateDirectory(destDirName);

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    if (subdir.Name.Contains(_backUpFolderName))
                        continue;

                    var tempPath = Path.Combine(destDirName, subdir.Name);
                    CopyDirectory(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}
