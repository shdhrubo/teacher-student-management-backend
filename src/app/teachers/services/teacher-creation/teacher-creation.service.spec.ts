import { TestBed } from '@angular/core/testing';

import { TeacherCreationService } from './teacher-creation.service';

describe('TeacherCreationService', () => {
  let service: TeacherCreationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeacherCreationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
