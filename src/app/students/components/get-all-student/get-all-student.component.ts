import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalErrorHandlingService } from '../../../services/global-error-handling/global-error-handling.service';
import { IStudent } from '../../student.model';
import { StudentGetAllService } from '../../services/student-get-all/student-get-all.service';
import { IStudentWithId } from '../../IStudentWithId.model';

@Component({
  selector: 'app-get-all-student',
  templateUrl: './get-all-student.component.html',
  styleUrls: ['./get-all-student.component.css'],
})
export class GetAllStudentComponent implements OnInit {
  students: IStudentWithId[] = [];

  constructor(
    private getAllStudentsService: StudentGetAllService,
    private router: Router
  ) {}

  ngOnInit(): void {
    setTimeout(() => {
      this.loadData();
    });
  }

  loadData(): void {
    this.getAllStudentsService.getStudents().subscribe(
      (data: IStudentWithId[]) => {
        this.students = data;
      },
      (error) => {
        // this.globalErrorHandler.handleError(error);
        console.log(error);
      }
    );
  }

  updateStudent(student: IStudentWithId) {
    this.router.navigate(['students/update-student', student.id]);
  }

  deleteStudent(student: IStudentWithId) {
    this.router.navigate(['students/delete-student', student.id]);
  }

  viewDetails(student: IStudentWithId) {
    this.router.navigate(['students/get-student-details', student.id]);
  }
}
