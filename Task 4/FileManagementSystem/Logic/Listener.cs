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

            using ( var _watcher = new FileSystemWatcher(_directoryPath))
            {
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

                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }



        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed || e.FullPath.Contains(_backUpFolderName))
                return;

            //Console.WriteLine($"Changed: {e.FullPath}");
            string time = DateTime.Now.ToString().Replace(':', '-');
            string toCopyDirectoryPath = $@"{_directoryPath}\{_backUpFolderName}\{time}";
            Directory.CreateDirectory(toCopyDirectoryPath);
            CopyFilesRecursively(_directoryPath, toCopyDirectoryPath);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.Contains(_backUpFolderName))
                return;
            //string value = $"Created: {e.FullPath}";
            //Console.WriteLine(value);
            string time = DateTime.Now.ToString().Replace(':', '-');
            string toCopyDirectoryPath = $@"{_directoryPath}\{_backUpFolderName}\{time}";
            Directory.CreateDirectory(toCopyDirectoryPath);
            CopyFilesRecursively(_directoryPath, toCopyDirectoryPath);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.Contains(_backUpFolderName))
            {
                return;
            }
            //Console.WriteLine($"Deleted: {e.FullPath}");
            string time = DateTime.Now.ToString().Replace(':', '-');
            string toCopyDirectoryPath = $@"{_directoryPath}\{_backUpFolderName}\{time}";
            Directory.CreateDirectory(toCopyDirectoryPath);
            CopyFilesRecursively(_directoryPath, toCopyDirectoryPath);
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (e.FullPath.Contains(_backUpFolderName))
                return;


            //Console.WriteLine($"Renamed:");
            //Console.WriteLine($"    Old: {e.OldFullPath}");
            //Console.WriteLine($"    New: {e.FullPath}");
            string time = DateTime.Now.ToString().Replace(':', '-');
            string toCopyDirectoryPath = $@"{_directoryPath}\{_backUpFolderName}\{time}";
            Directory.CreateDirectory(toCopyDirectoryPath);
            CopyFilesRecursively(_directoryPath, toCopyDirectoryPath);
        }

        private void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                if (dirPath.Contains(_backUpFolderName))
                    break;
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                if (newPath.Contains(_backUpFolderName))
                    break;
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
