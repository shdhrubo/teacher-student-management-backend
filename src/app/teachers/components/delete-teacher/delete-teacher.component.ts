import { Component } from '@angular/core';
import { TeacherDeleteService } from '../../services/teacher-delete/teacher-delete.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GlobalErrorHandlingService } from '../../../services/global-error-handling/global-error-handling.service';

@Component({
  selector: 'app-delete-teacher',
  templateUrl: './delete-teacher.component.html',
  styleUrls: ['./delete-teacher.component.css'],
})
export class DeleteTeacherComponent {
  teacherId: number = 0;

  constructor(
    private teacherDeleteService: TeacherDeleteService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
  ) {
    this.route.params.subscribe((params) => {
      this.teacherId = +params['id'];
    });
  }

  confirmDelete(): void {
    this.teacherDeleteService.deleteTeacher(this.teacherId).subscribe(
      () => {
        //alert('Teacher deleted successfully');
        this.toastr.success('Success', 'Teacher deleted successfully');
        this.router.navigate(['/teachers/get-all-teachers']);
      },
      (error) => {
       // this.globalErrorHandler.handleError(error);
       console.log(error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/teachers']);
  }
}
