using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public partial class PredictionDate
    {
        [Key, ForeignKey("Forecast")]
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public virtual ICollection<Forecast> Forecast { get; set; }
    }
}
