using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Logic
{
    public class Listener : IDisposable
    {
        private readonly string _backUpFolderName = ConfigurationManager.AppSettings["backUpFolderName"];
        private string _directoryPath;
        private FileSystemWatcher _watcher;

        public Listener(string directoryPath)
        {
            _directoryPath = directoryPath;
        }


        public void Start()
        {
            var backUpDir = Path.Combine(_directoryPath, _backUpFolderName);    

            if (!Directory.Exists(backUpDir))
            {
                DirectoryInfo di = Directory.CreateDirectory(backUpDir);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            _watcher = new FileSystemWatcher(_directoryPath);
            _watcher.NotifyFilter = NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;

            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreatedDeletedRenamed;
            _watcher.Deleted += OnCreatedDeletedRenamed;
            _watcher.Renamed += OnCreatedDeletedRenamed;

            _watcher.Filter = ConfigurationManager.AppSettings["filterTemplate"];
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            _watcher?.Dispose();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed || ContainsFolder(e.FullPath, _backUpFolderName))
                return;

            BackUpChanges();
        }

        private void OnCreatedDeletedRenamed(object sender, FileSystemEventArgs e)
        {
            if (ContainsFolder(e.FullPath, _backUpFolderName))
                return;

            BackUpChanges();
        }

        private bool ContainsFolder(string path, string folderName)
        {
            return path.Split(Path.DirectorySeparatorChar).Contains(folderName);
        }

        private void BackUpChanges()
        {
            string time = DateTime.Now.ToString("dd.MM.yyyy hh-mm-ss");
            string toCopyDirectoryPath = $@"{_directoryPath}\{_backUpFolderName}\{time}";

            if (!Directory.Exists(toCopyDirectoryPath))
            {
                Directory.CreateDirectory(toCopyDirectoryPath);
                DirectoryHelper.CopyDirectory(_directoryPath, toCopyDirectoryPath, _backUpFolderName);
            }
        }
    }
}
