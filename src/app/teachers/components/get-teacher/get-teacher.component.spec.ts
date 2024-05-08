import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTeacherComponent } from './get-teacher.component';

describe('GetTeacherComponent', () => {
  let component: GetTeacherComponent;
  let fixture: ComponentFixture<GetTeacherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetTeacherComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
