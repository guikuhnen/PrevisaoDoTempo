import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WeatherService } from '../services/weather/weather.service';
import { AlertifyService } from '../services/alertify/alertify.service';
import { CityForecast } from '../models/city-forecast';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent implements OnInit {
  forecastInfo: CityForecast = { message: '', cod: '', list: null, cnt: 0 };
  temperatureChart: any;
  humidityPressureChart: any;
  cityCustomCode: string;

  constructor(
    private route: ActivatedRoute,
    private weatherService: WeatherService,
    private alertify: AlertifyService,
    private commonService: CommonService
  ) { }

  ngOnInit() {
    this.cityCustomCode = this.route.snapshot.paramMap.get('customCode');

    this.weatherService.getForecast(this.cityCustomCode).subscribe(
      (forecast: CityForecast) => {
        this.forecastInfo = forecast;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  getDates(): string[] {
    let weatherDates = [];
    this.forecastInfo.list
      .map(res => res.dt)
      .forEach((res: number) => {
        weatherDates.push(this.commonService.formatDateFromNumber(res));
      });
    return weatherDates;
  }

  formatDateToGraph(jsDateAsNumber: number): string {
    return this.commonService
      .formatDateFromNumber(jsDateAsNumber);
  }

  fixTemperature(temp: number): string {
    return temp.toFixed(0);
  }
}
