import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { TeacherGetAllService } from '../../services/teacher-get-all/teacher-get-all.service';
import { ITeacherWithId } from '../../ITeacherWithId.model';
import { Router } from '@angular/router';
import { GlobalErrorHandlingService } from '../../../services/global-error-handling/global-error-handling.service';
import {
  MatDialog,
  MatDialogConfig,
  MatDialogRef,
} from '@angular/material/dialog';
import { DeleteTeacherDialogComponent } from '../delete-teacher-dialog/delete-teacher-dialog.component';
import { TeacherDeleteService } from '../../services/teacher-delete/teacher-delete.service';

@Component({
  selector: 'app-get-all-teacher',
  templateUrl: './get-all-teacher.component.html',
  styleUrls: ['./get-all-teacher.component.css'],
})
export class GetAllTeacherComponent implements OnInit {
  teachers: ITeacherWithId[] = [];
  displayedColumns: string[] = ['id', 'name', 'email', 'subject', 'actions'];
  currentPage: number = 1;
  pageSize: number = 10;
  totalTeachers: number = 0;

  totalPages: number = 0;
  constructor(
    private getAllTeachersService: TeacherGetAllService,
    private router: Router,
    public dialog: MatDialog,
    private deleteTeacherService: TeacherDeleteService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    setTimeout(() => {
      this.loadData();
    });
  }

  loadData(): void {
    // this.isLoading = true;
    console.log(this.currentPage, this.totalPages);
    this.getAllTeachersService
      .getTeachers(this.currentPage, this.pageSize)
      .subscribe(
        (data: any) => {
          this.teachers = data.teachers;
          this.totalTeachers = data.totalTeachers;
          this.totalPages = Math.ceil(this.totalTeachers / this.pageSize);
        },
        (error) => {
          console.log(error);
        }
      );
  }

  updateTeacher(teacher: ITeacherWithId) {
    this.router.navigate(['teachers/update-teacher', teacher.id]);
  }

  // deleteTeacher(teacher: ITeacherWithId) {
  //   this.router.navigate(['teachers/delete-teacher', teacher.id]);
  // }

  viewDetails(teacher: ITeacherWithId) {
    this.router.navigate(['teachers/get-teacher-details', teacher.id]);
  }

  nextPage(): void {
    if (this.currentPage * this.pageSize < this.totalTeachers) {
      this.currentPage++;
      this.loadData();
    }
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadData();
    }
  }
  //delete functionality
  openDeleteDialog(teacher: ITeacherWithId): void {
    const dialogRef = this.dialog.open(DeleteTeacherDialogComponent, {
      width: '250px',
      panelClass: 'custom-dialog-container',
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.deleteTeacherService.deleteTeacher(teacher.id).subscribe(
          () => {
            this.loadData();
            this.toastr.success('Success', 'Teacher deleted successfully');
          },
          (error) => {
            // this.globalErrorHandler.handleError(error);
          }
        );
      }
    });
  }
  // openDeleteDialog(teacher: ITeacherWithId) {
  //   const dialogConfig = new MatDialogConfig();
  //   dialogConfig.width = '250px';
  //   dialogConfig.data = { teacher: teacher };
  //   dialogConfig.panelClass = 'custom-dialog-container';
  //   const dialogRef: MatDialogRef<DeleteTeacherDialogComponent> =
  //     this.dialog.open(DeleteTeacherDialogComponent, dialogConfig);

  //   dialogRef.afterClosed().subscribe((result: any) => {
  //     if (result) {
  //       this.deleteTeacherService.deleteTeacher(teacher.id).subscribe(
  //         () => {
  //           this.loadData();
  //           this.toastr.success('Success', 'Teacher deleted successfully');
  //         },
  //         (error: any) => {
  //           // console.error('Error deleting teacher:', error);
  //         }
  //       );
  //     }
  //   });
  // }
}
