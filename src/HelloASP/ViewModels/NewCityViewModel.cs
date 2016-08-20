using HelloASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASP.ViewModels
{
    public class NewCityViewModel
    {
        public City City { get; set; }
        public int Temp { get; set; }
        public string Description { get; set; }
    }
}
