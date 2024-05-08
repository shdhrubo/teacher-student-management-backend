import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetStudentDetailsComponent } from './get-student-details.component';

describe('GetStudentDetailsComponent', () => {
  let component: GetStudentDetailsComponent;
  let fixture: ComponentFixture<GetStudentDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetStudentDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetStudentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
