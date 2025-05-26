namespace Cab_Frontend.Models
{
    public class WeatherResponse
    {
        public LocationInfo location { get; set; }
        public CurrentWeather current { get; set; }
    }

    public class LocationInfo
    {
        public string name { get; set; }
        public string country { get; set; }
    }

    public class CurrentWeather
    {
        public double temp_c { get; set; }
        public Condition condition { get; set; }
    }

    public class Condition
    {
        public string text { get; set; }
    }
}
