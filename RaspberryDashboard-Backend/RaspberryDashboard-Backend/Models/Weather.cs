namespace RaspberryDashboard_Backend.Models
{
    public class Weather
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int WeahterId { get; set; }
        public string WeatherName { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
        public double Temperature { get; set; }
        public double TemperatureFeel { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }
        public int WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}