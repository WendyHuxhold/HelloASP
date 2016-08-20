using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASP.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public City City { get; set; }
        public DateTime ForecastDate { get; set; }
        public int Temp { get; set; }
        public int Precipitation { get; set; }
        public int HighTemp { get; set; }
        public int LowTemp { get; set; }
        public string Description { get; set; }
    }
}
