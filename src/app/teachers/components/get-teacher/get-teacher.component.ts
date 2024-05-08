import { Component } from '@angular/core';
import { ITeacher } from '../../teacher.model';
import { TeacherGetService } from '../../services/teacher-get/teacher-get.service';

@Component({
  selector: 'app-get-teacher',
  templateUrl: './get-teacher.component.html',
  styleUrl: './get-teacher.component.css',
})
export class GetTeacherComponent {
  teacherId: number = 0;
  teacher: ITeacher = {  name: "", email: "", subject: "" };
  constructor(private teacherGetService: TeacherGetService) {}
 

  getTeacherInfo() {
   
    this.teacherGetService.getTeacherById(this.teacherId)
      .subscribe(
        (teacher: ITeacher) => {
          console.log("success!");
          this.teacher = teacher;
        },
        (error) => {
          alert("Teacher id not found!");
          console.error('Error fetching teacher:', error);
          this.teacher = {  name: "", email: "", subject: "" }; 
        }
      );
  }
}
