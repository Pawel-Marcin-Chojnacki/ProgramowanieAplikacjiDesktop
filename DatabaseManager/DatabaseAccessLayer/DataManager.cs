using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    /// <summary>
    /// 
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DataManager(IDataContext context)
        {
            dataContext = context;
        }

        private IDataContext dataContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void CleanAllData(string path)
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
        }
    }
}
