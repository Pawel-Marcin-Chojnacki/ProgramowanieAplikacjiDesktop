using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public partial class City
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int ServiceId { get; set; }

        public bool Observed { get; set; }
    }
}