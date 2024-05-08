import { TestBed } from '@angular/core/testing';

import { TeacherDeleteService } from './teacher-delete.service';

describe('TeacherDeleteService', () => {
  let service: TeacherDeleteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeacherDeleteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
