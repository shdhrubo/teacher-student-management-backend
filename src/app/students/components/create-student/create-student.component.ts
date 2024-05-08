import { Component } from '@angular/core';
import { IStudent } from '../../student.model';
import { StudentCreationService } from '../../services/student-creation/student-creation.service';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrl: './create-student.component.css',
})
export class CreateStudentComponent {
  newStudent: IStudent = { name: '', email: '', teacherId: 0 };
  constructor(
    private studentCreationService: StudentCreationService,
    private toastr: ToastrService
  ) {}
  submitForm() {
    console.log(this.newStudent);
    this.studentCreationService.createStudent(this.newStudent).subscribe(
      (student: IStudent) => {
        this.toastr.success('Student created successfully');
        this.resetForm();
      },
      (error) => {
        console.error('Error creating student:', error);
      }
    );
  }
  resetForm() {
    this.newStudent = { name: '', email: '', teacherId: 0 };
  }
}
