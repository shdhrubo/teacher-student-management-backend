import { Component, OnInit } from '@angular/core';
import { IStudent } from '../../student.model';
import { StudentGetService } from '../../services/student-get/student-get.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-get-student-details',
  templateUrl: './get-student-details.component.html',
  styleUrls: ['./get-student-details.component.css'],
})
export class GetStudentDetailsComponent implements OnInit {
  studentId: number = 0;
  student: IStudent = { name: '', email: '', teacherId: 0 };

  constructor(
    private studentGetService: StudentGetService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.studentId = +params['id'];
      this.studentGetService.getStudentById(this.studentId).subscribe(
        (student: IStudent) => {
          console.log('Success!');
          this.student = student;
        },
        (error) => {
          alert('Student ID not found!');
          console.error('Error fetching student:', error);
          this.student = { name: '', email: '', teacherId: 0 };
        }
      );
    });
  }
}
