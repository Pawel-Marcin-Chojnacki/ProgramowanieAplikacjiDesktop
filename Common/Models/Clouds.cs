using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public partial class Clouds
    {
        [Key, ForeignKey("Forecast")]
        public int Id { get; set; }

        public long All { get; set; }

        public virtual ICollection<Forecast> Forecast { get; set; }
    }
}
