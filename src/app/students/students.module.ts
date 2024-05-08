import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentsHomeComponent } from './components/students-home/students-home.component';
import { CreateStudentComponent } from './components/create-student/create-student.component';
import { GetStudentComponent } from './components/get-student/get-student.component';
import { UpdateStudentComponent } from './components/update-student/update-student.component';
import { DeleteStudentComponent } from './components/delete-student/delete-student.component';
import { RouterLink, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { GetAllStudentComponent } from './components/get-all-student/get-all-student.component';
import { GetStudentDetailsComponent } from './components/get-student-details/get-student-details.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    StudentsHomeComponent,
    CreateStudentComponent,
    GetStudentComponent,
    UpdateStudentComponent,
    DeleteStudentComponent,
    GetAllStudentComponent,
    GetStudentDetailsComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    RouterLink,
    MatTableModule,
    MatListModule,
    MatCardModule,
    MatFormFieldModule,
    MatFormField,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
  ],
  exports: [
    StudentsHomeComponent,
    CreateStudentComponent,
    GetStudentComponent,
    UpdateStudentComponent,
    DeleteStudentComponent,
    GetAllStudentComponent,
  ],
})
export class StudentsModule {}
