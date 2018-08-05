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
        public DataManager(IDataContext context)
        {
            dataContext = context;
        }

        private IDataContext dataContext;

        public void CleanAllData(string path)
        {
            File.Delete(path);
        }
    }
}
