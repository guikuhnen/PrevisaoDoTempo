import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WeatherService } from '../services/weather/weather.service';
import { AlertifyService } from '../services/alertify/alertify.service';
import { Chart } from 'chart.js';
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
        this.createTemperatureChart();
        this.createHumidityPressureChart();
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  createHumidityPressureChart() {
    const humidity = this.forecastInfo.list.map(res => res.main.humidity);
    const pressure = this.forecastInfo.list.map(res => res.main.pressure);

    this.humidityPressureChart = new Chart('humidityPressureChart', {
      type: 'bar',
      data: {
        labels: this.getDates(),
        datasets: [
          {
            data: humidity,
            backgroundColor: '#3cba9f',
            fill: true,
            label: 'Umidade do ar (%)'
          },
          {
            data: pressure,
            backgroundColor: '#ffcc00',
            fill: true,
            label: 'Pressão Atmosférica'
          }
        ]
      },
      options: {
        legend: {
          display: true
        },
        scales: {
          xAxes: [{ display: true }],
          yAxes: [{ display: true }]
        }
      }
    });
  }

  createTemperatureChart() {
    const tempMax = this.forecastInfo.list.map(res =>
      res.main.temp_max.toFixed(2)
    );
    const tempMin = this.forecastInfo.list.map(res =>
      res.main.temp_min.toFixed(2)
    );

    this.temperatureChart = new Chart('temperatureChart', {
      type: 'line',
      data: {
        labels: this.getDates(),
        datasets: [
          {
            data: tempMax,
            borderColor: '#3cba9f',
            fill: true,
            label: 'Temperatura Máxima (ºC)'
          },
          {
            data: tempMin,
            borderColor: '#ffcc00',
            fill: true,
            label: 'Temperatura Mínima (ºC)'
          }
        ]
      },
      options: {
        legend: {
          display: true
        },
        scales: {
          xAxes: [{ display: true }],
          yAxes: [{ display: true }]
        }
      }
    });
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
}
