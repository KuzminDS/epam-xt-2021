using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Logic
{
    public class RollbackService
    {
        private const string _backUpFolderName = ".customGit";
        private string _directoryPath;

        public RollbackService(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void Rollback(DateTime dateTime)
        {
            var backUpDirName = string.Join(@"\", _directoryPath, _backUpFolderName);
            var backUpDir = new DirectoryInfo(backUpDirName);

            if (!backUpDir.Exists)
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + backUpDirName);

            var dirs = backUpDir.GetDirectories();

            if (dirs.Length == 0)
                throw new DirectoryNotFoundException("Back up directory does not exist or could not be found");

            foreach (var dir in dirs)
            {
                if(dateTime == DateTime.Parse(dir.Name.Replace('-', ':')))
                {
                    CleanDirectory(_directoryPath);
                    CopyDirectory(string.Join(@"\", backUpDirName, dir.Name), _directoryPath, true);
                    break;
                }
            }



            //    foreach (var subdir in dirs)
            //    {
            //        if (subdir.Name.Contains(_backUpFolderName))
            //            continue;

            //        var tempPath = Path.Combine(destDirName, subdir.Name);
            //        CopyDirectory(subdir.FullName, tempPath, copySubDirs);
            //    }
            //}
        }

        public static void CleanDirectory(string directoryPath)
        {
            var dir = new DirectoryInfo(directoryPath);

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Directory does not exist or could not be found: " + directoryPath);

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

        private void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);

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
