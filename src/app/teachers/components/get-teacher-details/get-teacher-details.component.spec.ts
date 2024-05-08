import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTeacherDetailsComponent } from './get-teacher-details.component';

describe('GetTeacherDetailsComponent', () => {
  let component: GetTeacherDetailsComponent;
  let fixture: ComponentFixture<GetTeacherDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetTeacherDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetTeacherDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
