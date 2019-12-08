import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { ForecastComponent } from './forecast/forecast.component';
import { HomeComponent } from './home/home.component';
import { CityListComponent } from './home/city-list/city-list.component';
import { CitySearchComponent } from './home/city-search/city-search.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ForecastCarouselComponent } from './forecast/forecast-carousel/forecast-carousel.component';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        AppRoutingModule,
        FormsModule,
        HttpClientTestingModule
      ],
      declarations: [
        AppComponent,
        ForecastComponent,
        HomeComponent,
        CityListComponent,
        CitySearchComponent,
        ForecastCarouselComponent
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'Previsão do Tempo'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Previsão do Tempo');
  });

  /* it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('.content span').textContent).toContain('Visual-PrevisaoDoTempo app is running!');
  }); */
});
