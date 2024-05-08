import { TestBed } from '@angular/core/testing';

import { StudentCreationService } from './student-creation.service';

describe('StudentCreationService', () => {
  let service: StudentCreationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentCreationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
