import { TestBed } from '@angular/core/testing';

import { TeacherGetService } from './teacher-get.service';

describe('TeacherGetService', () => {
  let service: TeacherGetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeacherGetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
