using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Logic
{
    public class Listener
    {
        private const string _backUpFolderName = ".customGit";
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

            _watcher.Filter = "*.txt";
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        public void End()
        {
            _watcher.Dispose();
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
            string time = DateTime.Now.ToString().Replace(':', '-');
            string toCopyDirectoryPath = $@"{_directoryPath}\{_backUpFolderName}\{time}";

            if (!Directory.Exists(toCopyDirectoryPath))
            {
                Directory.CreateDirectory(toCopyDirectoryPath);
                CopyDirectory(_directoryPath, toCopyDirectoryPath, true);
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
