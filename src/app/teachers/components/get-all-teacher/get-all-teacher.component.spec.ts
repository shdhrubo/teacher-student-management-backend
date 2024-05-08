import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllTeacherComponent } from './get-all-teacher.component';

describe('GetAllTeacherComponent', () => {
  let component: GetAllTeacherComponent;
  let fixture: ComponentFixture<GetAllTeacherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetAllTeacherComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetAllTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
