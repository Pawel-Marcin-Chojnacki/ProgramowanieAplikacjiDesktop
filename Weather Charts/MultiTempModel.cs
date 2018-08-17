using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Charts
{
     public class MultiTempModel
    {

        public List<double> MinTemperatures { get; set; }

        public List<double> MaxTemperatures { get; set; }

        public List<string> Cities { get; set; }
    }
}
