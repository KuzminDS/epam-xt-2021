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

        public void Rollback(DateTime rollbackDt)
        {
            var backUpDirName = Path.Combine(_directoryPath, _backUpFolderName);
            var backUpDir = new DirectoryInfo(backUpDirName);

            if (!backUpDir.Exists)
                throw new DirectoryNotFoundException("Директория не найдена или она не существует: " + backUpDirName);

            var dirs = backUpDir.GetDirectories();

            if (dirs.Length == 0)
                throw new DirectoryNotFoundException("Директория для отката не найдена или она не существует или она пустая");

            var dirDateTimes = dirs.Select(d => DateTime.ParseExact(d.Name, "dd.MM.yyyy HH-mm-ss", CultureInfo.InvariantCulture));

            if (rollbackDt < dirDateTimes.FirstOrDefault())
                throw new DirectoryNotFoundException("Директория не может откатиться на указанное время, так как резервная копия на данный момент не была записана");

            var backUpDateTime = dirDateTimes.OrderByDescending(dt => dt).FirstOrDefault(dt => dt <= rollbackDt);

            DirectoryHelper.CleanDirectory(_directoryPath, _backUpFolderName);
            DirectoryHelper.CopyDirectory(Path.Combine(backUpDirName, backUpDateTime.ToString("dd.MM.yyyy HH-mm-ss")), _directoryPath, _backUpFolderName);
        }
    }
}
