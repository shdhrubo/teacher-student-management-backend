import { Component } from '@angular/core';
import { StudentDeleteService } from '../../services/student-delete/student-delete.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GlobalErrorHandlingService } from '../../../services/global-error-handling/global-error-handling.service';

@Component({
  selector: 'app-delete-student',
  templateUrl: './delete-student.component.html',
  styleUrls: ['./delete-student.component.css'],
})
export class DeleteStudentComponent {
  studentId: number = 0;

  constructor(
    private studentDeleteService: StudentDeleteService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
  ) {
    this.route.params.subscribe((params) => {
      this.studentId = +params['id'];
    });
  }

  confirmDelete(): void {
    this.studentDeleteService.deleteStudent(this.studentId).subscribe(
      () => {
        this.toastr.success('Success', 'Student deleted successfully');
        this.router.navigate(['/students/get-all-students']);
      },
      (error) => {
       // this.globalErrorHandler.handleError(error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/students']);
  }
}
