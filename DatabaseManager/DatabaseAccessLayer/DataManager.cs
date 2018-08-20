using DatabaseManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace DatabaseManager
{
    public class DataManager
    {
        private readonly IFileSystem fileSystem;
        private EventLogger logger;

        public DataManager(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            logger = new EventLogger();
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
                logger.WriteMessage("Failed to get a forecast from webservice.\n" + exception.Message);
                return false;
            }
            return true;
        }
    }
}
