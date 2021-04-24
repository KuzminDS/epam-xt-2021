using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Logic
{
    public class Listener
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
            Directory.SetCurrentDirectory(_directoryPath);

            if (!Directory.Exists(_backUpFolderName))
            {
                DirectoryInfo di = Directory.CreateDirectory(_backUpFolderName);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            _watcher = new FileSystemWatcher(_directoryPath);
            _watcher.NotifyFilter = NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;

            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;

            _watcher.Filter = ConfigurationManager.AppSettings["filterTemplate"];
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        public void End()
        {
            _watcher?.Dispose();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed || e.FullPath.Contains(_backUpFolderName))
                return;

            BackUpChanges();
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.Contains(_backUpFolderName))
                return;

            BackUpChanges();
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.Contains(_backUpFolderName))
                return;

            BackUpChanges();
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (e.FullPath.Contains(_backUpFolderName))
                return;

            BackUpChanges();
        }

        private void BackUpChanges()
        {
            string time = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss").Replace(':', '-');
            string toCopyDirectoryPath = $@"{_directoryPath}\{_backUpFolderName}\{time}";

            if (!Directory.Exists(toCopyDirectoryPath))
            {
                Directory.CreateDirectory(toCopyDirectoryPath);
                DirectoryHelper.CopyDirectory(_directoryPath, toCopyDirectoryPath, true);
            }
        }
    }
}
