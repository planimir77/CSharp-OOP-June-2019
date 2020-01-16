using System;
using System.Linq;
using System.Globalization;
using Logger.DateFormat;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.IOManagement;

namespace Logger.Models.File
{
    public class LogFile:IFile
    {
        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        private string currentPath;
        private IIOManager ioManager;

        public LogFile()
        {
            this.ioManager = new IOManager(currentDirectory, currentFile);
            this.currentPath = this.ioManager.GetCurrentPath();
            this.ioManager.EnsureDirectoryAndFileExist();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        public string Path
        {
            get
            {
                return this.currentPath;
            }
            private set
            {
                this.currentPath = value;
            }
        }

        public ulong Size
        {
            get
            {
                return GetFileSize();
            }
        }



        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;
            
            string formattedMessage = String.Format(format,
                dateTime.ToString(DateTimeFormat.DateFormat,CultureInfo.InvariantCulture),
                level.ToString(),
                message);
            

            return formattedMessage;
        }

        private ulong GetFileSize()
        {
            string text = System.IO.File.ReadAllText(this.Path);

            ulong size = (ulong) text
                .ToCharArray()
                .Where(c => Char.IsLetter(c))
                .Sum(c => (int) c);

            return size;
        }
    }
}
