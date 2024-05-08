import { TestBed } from '@angular/core/testing';

import { StudentGetAllService } from './student-get-all.service';

describe('StudentGetAllService', () => {
  let service: StudentGetAllService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentGetAllService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
