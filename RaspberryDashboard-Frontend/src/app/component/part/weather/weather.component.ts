import { Component, OnInit } from '@angular/core';
import {WeatherService} from '../../../service/weather.service';
import {OpenWeather} from '../../../model/weather/open-weather';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {
  weather: OpenWeather = new OpenWeather();

  constructor(public weatherService: WeatherService) {
    if (localStorage.getItem('location') === null) {
      localStorage.setItem('location', 'Eindhoven');
    }
    const location = localStorage.getItem('location');
    this.weatherService.getWeather(location).subscribe(weather => {
      this.weather = weather;
    });
  }

  ngOnInit(): void {
  }

}
