using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public partial class City
    {
        [Key, ForeignKey("Forecast")]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int ServiceId { get; set; }

        public bool Observed { get; set; }

        public virtual ICollection<Forecast> Forecast { get; set; }
    }
}