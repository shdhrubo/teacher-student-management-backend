import { TeacherGetService } from './../../services/teacher-get/teacher-get.service';
import { Component, OnInit } from '@angular/core';
import { ITeacher } from '../../teacher.model';
import { ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../../services/loading-service/loading-service.service';

@Component({
  selector: 'app-get-teacher-details',
  templateUrl: './get-teacher-details.component.html',
  styleUrl: './get-teacher-details.component.css',
})
export class GetTeacherDetailsComponent implements OnInit {
  teacherId: number = 0;
  teacher: ITeacher = { name: '', email: '', subject: '' };

  constructor(
    private teacherGetService: TeacherGetService,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    setTimeout(() => {
      this.route.params.subscribe((params) => {
        this.teacherId = +params['id'];
        this.teacherGetService.getTeacherById(this.teacherId).subscribe(
          (teacher: ITeacher) => {
            this.teacher = teacher;
          },
          (error) => {
            alert('Teacher id not found!');
            console.error('Error fetching teacher:', error);
            this.teacher = { name: '', email: '', subject: '' };
          }
        );
      });
    });
  }
}
