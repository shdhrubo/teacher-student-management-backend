import { TestBed } from '@angular/core/testing';

import { StudentGetService } from './student-get.service';

describe('StudentGetService', () => {
  let service: StudentGetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentGetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
