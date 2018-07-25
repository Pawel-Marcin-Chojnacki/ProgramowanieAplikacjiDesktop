using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public partial class Forecast
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public int WeatherId { get; set; }

        public int WindId { get; set; }

        public int CloudsId { get; set; }

        public int TimeId { get; set; }
    }
}
