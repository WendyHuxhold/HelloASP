using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using HelloASP.Models;
using HelloASP.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASP.Controllers
{
    /*
     * GET /api/cities
     * GET /api/cities/5
     * POST  /api/cities
     * PUT /api/cities/5
     * DELETE /api/cities/5
     */
     
    [Route("api/[controller]")]
    //[/api/cities] - takes the "api" from the route and the first part of the controller, in this case
    //cities.
    public class CitiesController : Controller
    {
        #region Cities List
        public static IList<City> _cities = new List<City>()
        {
            new City() {
                Name = "Houston",
                State = "TX",
                Forecasts = new List<Forecast>
                {
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now,
                        Temp = 69,
                        HighTemp = 75,
                        LowTemp = 52,
                        Precipitation = 20,
                        Description = "Cloudy"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(1),
                        Temp = 80,
                        HighTemp = 85,
                        LowTemp = 78,
                        Precipitation = 20,
                        Description = "Sunny"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(2),
                        Temp = 86,
                        HighTemp = 90,
                        LowTemp = 80,
                        Precipitation = 20,
                        Description = "Rainy"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(3),
                        Temp = 65,
                        HighTemp = 78,
                        LowTemp = 62,
                        Precipitation = 10,
                        Description = "Sunny"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(4),
                        Temp = 70,
                        HighTemp = 75,
                        LowTemp = 55,
                        Precipitation = 80,
                        Description = "Thunderstorms"
                    }
                }
            },
            new City() {
                Name = "Seattle",
                State = "WA",
                Forecasts = new List<Forecast>
                {
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now,
                        Temp = 55,
                        HighTemp = 65,
                        LowTemp = 52,
                        Precipitation = 20,
                        Description = "Cloudy"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(1),
                        Temp = 60,
                        HighTemp = 72,
                        LowTemp = 42,
                        Precipitation = 10,
                        Description = "Sunny"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(2),
                        Temp = 62,
                        HighTemp = 70,
                        LowTemp = 55,
                        Precipitation = 50,
                        Description = "Rainy"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(3),
                        Temp = 65,
                        HighTemp = 78,
                        LowTemp = 62,
                        Precipitation = 10,
                        Description = "Sunny"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(4),
                        Temp = 70,
                        HighTemp = 75,
                        LowTemp = 55,
                        Precipitation = 80,
                        Description = "Thunderstorms"
                    }
                }

            },
            new City() {
                Name = "Chicago",
                State = "IL",
                Forecasts = new List<Forecast>
                {
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now,
                        Temp = 55,
                        HighTemp = 65,
                        LowTemp = 45,
                        Precipitation = 40,
                        Description = "Cloudy"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(1),
                        Temp = 62,
                        HighTemp = 70,
                        LowTemp = 40,
                        Precipitation = 80,
                        Description = "Thunderstorms"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(2),
                        Temp = 86,
                        HighTemp = 90,
                        LowTemp = 80,
                        Precipitation = 20,
                        Description = "Rainy"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(3),
                        Temp = 65,
                        HighTemp = 78,
                        LowTemp = 62,
                        Precipitation = 10,
                        Description = "Sunny"
                    },
                    new Forecast()
                    {
                        ForecastDate = DateTime.Now.AddDays(4),
                        Temp = 70,
                        HighTemp = 75,
                        LowTemp = 55,
                        Precipitation = 80,
                        Description = "Thunderstorms"
                    }
                }

            }
        };
        #endregion

        // GET: api/cities
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _cities;
        }

        // GET api/cities/TX/Houston
        // GET api/cities/IL/Chicago
        // 2 routes
        [HttpGet("{state}/{city}")]
        public City Get(string state,string city)
        {
            //return Cities.FirstOrDefault(c => c.State == state && c.Name == city); or use Linq
            //using Linq to return the city, everthing inside the parens are a Linq query
            return (from c in _cities
                    where c.State.ToLower() == state.ToLower() && c.Name.ToLower() == city.ToLower()
                    select c).FirstOrDefault();
            
            
        }

        // POST api/values
        //[FromBody] is an attribute that gives us additional information
        // takes the body of our post and converts it to a string
        //changed the type of newCity from City to NewCityViewModel to accomodate multiple objects
        [HttpPost]
        public IActionResult Post([FromBody]NewCityViewModel newCity)
        {
            if (ModelState.IsValid)
            {
                newCity.City.Forecasts = new List<Forecast>() {
                    new Forecast()
                    {
                        Temp = newCity.Temp,
                        Description = newCity.Description
                    }
                };
                _cities.Add(newCity.City);
                return Ok();
            }
            else
            {
                return HttpBadRequest(ModelState);
            };
            
        }

        //POST /api/cities/TX/Dallas -- the controller url + the method url ("{state}/{cityName}")
        [HttpPost("{state}/{cityName}")]
        public void PostForecast([FromBody]Forecast newForecast, string state, string cityName)
        {
            var city = (from c in _cities
                        where c.State.ToLower() == state.ToLower() && c.Name.ToLower() == cityName.ToLower()
                        select c).FirstOrDefault();
            city.Forecasts.Add(newForecast);
        }
        
        // PUT api/values/5

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]City newCity)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
