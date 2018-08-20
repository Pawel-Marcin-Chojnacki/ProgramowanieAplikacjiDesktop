using DatabaseManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class DataManager
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IFileSystem fileSystem;
        public DataManager(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public DataManager() : this( fileSystem: new FileSystem())
        {
        }

        public bool CleanAllData(string path)
        {
            try
            {
                fileSystem.File.Delete(path);
            }
            catch (Exception exception)
            {
                //TODO: Log to Windows Events.
                return false;
            }
            return true;
        }
    }
}
