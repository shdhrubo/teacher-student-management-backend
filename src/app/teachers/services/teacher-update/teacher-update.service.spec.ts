import { TestBed } from '@angular/core/testing';

import { TeacherUpdateService } from './teacher-update.service';

describe('TeacherUpdateService', () => {
  let service: TeacherUpdateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeacherUpdateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
