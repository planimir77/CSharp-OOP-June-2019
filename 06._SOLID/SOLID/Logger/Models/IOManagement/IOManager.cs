using System.IO;
using Logger.Models.Contracts;

namespace Logger.Models.IOManagement
{
    public class IOManager:IIOManager
    {

        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
            
        }

        public IOManager(string currentDirectory, string currentFile)
        :this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        public string CurrentDirectoryPath
        {
            get
            {
                return this.currentPath 
                       + this.currentDirectory;
            }
        }

        public string CurrentFilePath
        {
            get
            {
                return this.CurrentDirectoryPath
                       + this.currentFile;
            }
        }

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            System.IO.File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
