class WeatherCoord {
  public Lon: number;
  public Lat: number;
}

class Weather {
  public Id: number;
  public Main: string;
  public Description: string;
  public Icon: string;
  public IconUrl: string;
}

class MainWeather {
  public Temp: number;
  public TempFeel: number;
  public TempMin: number;
  public TempMax: number;
  public Pressure: number;
  public Humidity: number;
}

class Wind {
  public Speed: number;
  public Deg: number;
}

export class OpenWeather {
  public Coord: WeatherCoord;
  public Weather: Weather[] = [];
  public Main: MainWeather;
  public Visibility: number;
  public Wind: Wind;
  public Place: string;

}
