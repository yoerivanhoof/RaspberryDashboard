import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {OpenWeather} from "../model/weather/open-weather";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(public httpClient: HttpClient) {

  }

  public getWeather(place:string): Observable<OpenWeather>{
    return this.httpClient.get<OpenWeather>(`${environment.backendURL}/weather/${place}`)
  }
}
