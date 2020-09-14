using System.Collections.Generic;

namespace CurrentWeatherApp
{
    public class WeatherData
    {
        public IList<ConsolidatedWeather> consolidated_weather { get; set; }
        public string title { get; set; }
        public int woeid { get; set; }
    }
}
