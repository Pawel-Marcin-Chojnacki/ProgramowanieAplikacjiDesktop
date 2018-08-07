using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public partial class Wind
    {
        public double Speed { get; set; }

        public double Direction { get; set; }

        [Key, ForeignKey("Forecast")]
        public int Id { get; set; }

        public virtual ICollection<Forecast> Forecast { get; set; }
    }
}
