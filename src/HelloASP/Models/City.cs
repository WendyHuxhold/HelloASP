using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASP.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<Forecast> Forecasts { get; set; }

        [Required (ErrorMessage = "You got to put in a city and a state.")]
        [StringLength(2)]
        //[RegularExpression(@"[A-Z]{2}")]
        public string State { get; set; }
    }
}
