﻿using System;
using System.Net.Http;
using Newtonsoft.Json;
using RaspberryDashboard_Backend.Models.Weather;

namespace RaspberryDashboard_Backend.Services
{
    public class WeatherService : IWeatherService
    {
        public OpenWeather GetWeather(string location)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (var response =
                        httpClient.GetAsync(
                            $"https://api.openweathermap.org/data/2.5/weather?q={location}&units=metric&appid={Environment.GetEnvironmentVariable("OpenWeatherApiKey")}")
                    )
                    {
                        return JsonConvert.DeserializeObject<OpenWeather>(response.Result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return new OpenWeather() { Error = e.Message };
                }
                
            }

            return new OpenWeather();
        }
    }
}