import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlertifyService } from './services/alertify/alertify.service';
import { HomeComponent } from './home/home.component';
import { CityService } from './services/city/city.service';
import { CityListComponent } from './home/city-list/city-list.component';
import { WeatherService } from './services/weather/weather.service';
import { HttpClientModule } from '@angular/common/http';
import { CitySearchComponent } from './home/city-search/city-search.component';
import { FormsModule } from '@angular/forms';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { ForecastComponent } from './forecast/forecast.component';
import { ForecastCarouselComponent } from './forecast/forecast-carousel/forecast-carousel.component';
import { CommonService } from './services/common.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CityListComponent,
    CitySearchComponent,
    ForecastComponent,
    ForecastCarouselComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AlertifyService,
    CityService,
    WeatherService,
    ErrorInterceptorProvider,
    CommonService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
