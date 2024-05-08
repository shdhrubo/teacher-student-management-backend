import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GlobalErrorHandlingService } from '../../../services/global-error-handling/global-error-handling.service';
import { StudentUpdateService } from '../../services/student-update/student-update.service';
import { StudentGetService } from '../../services/student-get/student-get.service';
import { IStudentWithId } from '../../IStudentWithId.model';

@Component({
  selector: 'app-update-student',
  templateUrl: './update-student.component.html',
  styleUrls: ['./update-student.component.css'],
})
export class UpdateStudentComponent implements OnInit {
  studentId: number = 0;
  updatedStudent: IStudentWithId = {
    id: this.studentId,
    name: '',
    email: '',
    teacherId: 0,
  };

  constructor(
    private studentUpdateService: StudentUpdateService,
    private studentGetService: StudentGetService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.studentId = +params['id'];
      this.studentGetService
        .getStudentById(this.studentId)
        .subscribe((student: IStudentWithId) => {
          console.log('success!');
          this.updatedStudent = student;
        });
    });
  }

  submitForm(): void {
    this.updatedStudent.id = this.studentId;

    this.studentUpdateService
      .updateStudent(this.studentId, this.updatedStudent)
      .subscribe(
        (updatedStudent: IStudentWithId) => {
          this.toastr.success('Success', 'Student updated successfully');
        },
        (error) => {
          console.error(error);
        }
      );
  }
}
