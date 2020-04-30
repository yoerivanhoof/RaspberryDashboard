using Newtonsoft.Json;

namespace RaspberryDashboard_Backend.Models.Weather
{
    public class OpenWeather
    {
        [JsonProperty("coord")]
        public WeatherCoord Coord { get; set; }
        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty("main")]
        public MainWeather Main { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("name")]
        public string Place { get; set; }

        public string Error { get; set; }

    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public int Deg { get; set; }
    }

    public class MainWeather
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("feels_like")]
        public double TempFeel { get; set; }
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")] 
        public string Icon { get; set; }
    }

    public class WeatherCoord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

}