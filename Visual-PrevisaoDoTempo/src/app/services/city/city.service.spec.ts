import { TestBed, getTestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { CityService } from './city.service';

describe('CityService', () => {
  let injector: TestBed;
  let service: CityService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CityService]
    });
    injector = getTestBed();
    service = injector.get(CityService);
    httpMock = injector.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  describe('#getAllCities', () => {
    it('should return an Observable<City[]>', () => {
      const cidadesBase = [
        { name: 'Blumenau', customCode: 3469968, country: 'BR' },
        { name: 'Florianópolis', customCode: 3662616, country: 'BR' }
      ];

      service.getAllCities().subscribe(cities => {
        expect(cities.length).toBe(2);
        expect(cities).toEqual(cidadesBase);
      });

      const req = httpMock.expectOne(service.baseUrl);
      expect(req.request.method).toBe('GET');
      req.flush(cidadesBase);
    });
  });

  describe('#insertCity', () => {
    it('should return an Observable<City> with same city', () => {
      const cidadeBase = {
        name: 'Blumenau',
        customCode: 3469968,
        country: 'BR'
      };

      service.insertCity(cidadeBase).subscribe(insertedCity => {
        expect(insertedCity.name).toBe('Blumenau');
        expect(insertedCity).toEqual(cidadeBase);
      });

      const req = httpMock.expectOne(service.baseUrl);
      expect(req.request.method).toBe('POST');
      req.flush(cidadeBase);
    });
  });
});
