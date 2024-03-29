import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { City } from 'src/app/models/city';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CityForecast } from 'src/app/models/city-forecast';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  baseUrl = environment.baseUrl + 'cities';
  constructor(private http: HttpClient) { }

  searchCities(cityName: string): Observable<City[]> {
    return this.http.get<City[]>(`${this.baseUrl}/search/${cityName}`);
  }

  getForecast(cityCustomCode: string): Observable<CityForecast> {
    return this.http.get<any>(`${this.baseUrl}/forecast/${cityCustomCode}`);
  }
}
