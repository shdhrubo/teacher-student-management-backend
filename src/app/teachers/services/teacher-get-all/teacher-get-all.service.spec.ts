import { TestBed } from '@angular/core/testing';

import { TeacherGetAllService } from './teacher-get-all.service';

describe('TeacherGetAllService', () => {
  let service: TeacherGetAllService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeacherGetAllService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
