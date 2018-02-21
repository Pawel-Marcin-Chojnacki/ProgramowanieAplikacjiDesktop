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

        public Coord Coord { get; set; }

        public string Country { get; set; }

        public string Cod { get; set; }

        public double Message { get; set; }

        public long Cnt { get; set; }

        public List[] List { get; set; }
    }

}
