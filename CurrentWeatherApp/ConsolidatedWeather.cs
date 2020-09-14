using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentWeatherApp
{
    public class ConsolidatedWeather
    {
        public long id { get; set; }
        public string weather_state_name { get; set; }
        public string weather_state_abbr { get; set; }
        public string applicable_date { get; set; }
        public decimal min_temp { get; set; }
        public decimal max_temp { get; set; }
        public decimal the_temp { get; set; }
        public decimal air_pressure { get; set; }
        public decimal humidity { get; set; }

    }
}
