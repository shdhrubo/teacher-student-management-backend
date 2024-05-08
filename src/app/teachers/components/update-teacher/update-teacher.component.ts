import { ITeacherWithId } from './../../ITeacherWithId.model';
import { Component, OnInit } from '@angular/core';
import { TeacherUpdateService } from '../../services/teacher-update/teacher-update.service';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GlobalErrorHandlingService } from '../../../services/global-error-handling/global-error-handling.service';
import { TeacherGetService } from '../../services/teacher-get/teacher-get.service';
import { ITeacher } from '../../teacher.model';
import { LoadingService } from '../../../services/loading-service/loading-service.service';

@Component({
  selector: 'app-update-teacher',
  templateUrl: './update-teacher.component.html',
  styleUrls: ['./update-teacher.component.css'],
})
export class UpdateTeacherComponent implements OnInit {
  teacherId: number = 0;
  updatedTeacher: ITeacherWithId = {
    id: this.teacherId,
    name: '',
    email: '',
    subject: '',
  };

  constructor(
    private teacherUpdateService: TeacherUpdateService,
    private teacherGetService: TeacherGetService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private globalErrorHandler: GlobalErrorHandlingService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.teacherId = +params['id'];
      this.teacherGetService
        .getTeacherById(this.teacherId)
        .subscribe((teacher: ITeacherWithId) => {
          this.updatedTeacher = teacher;
        });
    });
  }

  submitForm(): void {
    this.updatedTeacher.id = this.teacherId;

    this.teacherUpdateService
      .updateTeacher(this.teacherId, this.updatedTeacher)
      .subscribe(
        (updatedTeacher: ITeacherWithId) => {
          this.toastr.success('Success', 'Teacher updated successfully');
          this.updatedTeacher = {
            id: this.teacherId,
            name: '',
            email: '',
            subject: '',
          };
        },
        (error) => {
          this.globalErrorHandler.handleError(error);
        }
      );
  }
}
