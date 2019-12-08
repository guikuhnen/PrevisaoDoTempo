import { TestBed } from '@angular/core/testing';
import { CommonService } from './common.service';

describe('Service: Common', () => {
  let service: CommonService;
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CommonService]
    });
  });

  it('should create the service', () => {
    expect(service).toBeUndefined();

    service = TestBed.get(CommonService);
    
    expect(service).toBeDefined();
  });
});
