import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllStudentComponent } from './get-all-student.component';

describe('GetAllStudentComponent', () => {
  let component: GetAllStudentComponent;
  let fixture: ComponentFixture<GetAllStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetAllStudentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetAllStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
