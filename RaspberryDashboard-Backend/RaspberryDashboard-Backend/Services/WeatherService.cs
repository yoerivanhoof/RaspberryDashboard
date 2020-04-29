using System;
using System.Net.Http;
using RaspberryDashboard_Backend.Models;

namespace RaspberryDashboard_Backend.Services
{
    public class WeatherService : IWeatherService
    {
        public string GetWeather(string location)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={location}&units=metric&appid={Environment.GetEnvironmentVariable("OpenWeatherApiKey")}")) //todo
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync().Result);
                    return response.Result.Content.ReadAsStringAsync().Result;
                }
            }

            return "empty";
        }
    }
}