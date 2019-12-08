import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/models/city';
import { WeatherService } from 'src/app/services/weather/weather.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { CityService } from 'src/app/services/city/city.service';

@Component({
  selector: 'app-city-search',
  templateUrl: './city-search.component.html',
  styleUrls: ['./city-search.component.css']
})
export class CitySearchComponent implements OnInit {
  foundCities: City[] = [];
  model: any = {};
  pesquisaFeita = false;

  constructor(
    private weatherService: WeatherService,
    private alertify: AlertifyService,
    private cityService: CityService
  ) { }

  ngOnInit() { }

  searchCities(): void {
    if (this.model.cityName === undefined || this.model.cityName.length === 0 || this.model.cityName.length < 3) {
      this.alertify.error(
        'Por favor digite 3 ou mais caracteres para buscar a cidade.'
      );
      return;
    }
    this.weatherService.searchCities(this.model.cityName).subscribe(
      (cities: City[]) => {
        this.foundCities = cities;
      },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.pesquisaFeita = true;
      }
    );
  }

  saveCity(newCity: City): void {
    this.cityService.insertCity(newCity).subscribe(
      (insertedCity: City) => {
        this.alertify.success('Cidade cadastrada com sucesso!');
        this.cityService.noticeCityInsertion(insertedCity);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
