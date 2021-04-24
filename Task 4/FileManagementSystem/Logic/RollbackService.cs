using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Logic
{
    public class RollbackService
    {
        private readonly string _backUpFolderName = ConfigurationManager.AppSettings["backUpFolderName"];
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
                throw new DirectoryNotFoundException("Директория не найдена или она не существует: " + backUpDirName);

            var dirs = backUpDir.GetDirectories();

            if (dirs.Length == 0)
                throw new DirectoryNotFoundException("Директория для отката не найдена или она не существует");

            var dirDateTimes = dirs.Select(d => DateTime.ParseExact(d.Name.Replace('-', ':'), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture));

            if (dateTime < dirDateTimes.FirstOrDefault())
                throw new DirectoryNotFoundException("Директория не может откатиться на указанное время");

            var backUpDateTime = dirDateTimes.FirstOrDefault();

            foreach (var dt in dirDateTimes)
            {
                if (dateTime >= dt)
                    backUpDateTime = dt;
                else
                    break;
            }

            DirectoryHelper.CleanDirectory(_directoryPath);
            DirectoryHelper.CopyDirectory(string.Join(@"\", backUpDirName, backUpDateTime.ToString("dd.MM.yyyy HH-mm-ss")), _directoryPath, true);
        }
    }
}
