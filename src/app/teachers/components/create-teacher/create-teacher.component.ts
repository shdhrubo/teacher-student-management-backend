import { Component, OnInit } from '@angular/core';
import { ITeacher } from '../../teacher.model';
import { TeacherCreationService } from '../../services/teacher-creation/teacher-creation.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-teacher',
  templateUrl: './create-teacher.component.html',
  styleUrl: './create-teacher.component.css',
})
export class CreateTeacherComponent {
  newTeacher: ITeacher = { name: '', email: '', subject: '' };

  constructor(
    private teacherCreationService: TeacherCreationService,
    private toastService: ToastrService
  ) {}

  submitForm() {
    this.teacherCreationService.createTeacher(this.newTeacher).subscribe(
      (teacher: ITeacher) => {
        console.log(teacher);
        this.toastService.success('Success', 'Teacher Created Successfully');
        this.resetForm();
      },
      (error) => {
        // this.globalErrorHandler.handleError(error);
        console.error(error);
      }
    );
  }

  resetForm() {
    this.newTeacher = { name: '', email: '', subject: '' };
  }
}
