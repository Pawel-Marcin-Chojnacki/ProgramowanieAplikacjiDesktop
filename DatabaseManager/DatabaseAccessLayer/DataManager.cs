using DatabaseManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class DataManager
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private IDataContext dataContext;

        public DataManager(IDataContext context)
        {
            dataContext = context;
        }


        public bool CleanAllData(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                //TODO: Log to Windows Events.
                throw exception;
            }
            return true;
        }
    }
}
