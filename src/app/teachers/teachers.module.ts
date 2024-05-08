import { MaterialButtonComponent } from './../reusable-component/material-button/material-button.component';
import { MatTableModule } from '@angular/material/table';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeachersHomeComponent } from './components/teachers-home/teachers-home.component';
import { CreateTeacherComponent } from './components/create-teacher/create-teacher.component';
import { GetTeacherComponent } from './components/get-teacher/get-teacher.component';
import { UpdateTeacherComponent } from './components/update-teacher/update-teacher.component';
import { DeleteTeacherComponent } from './components/delete-teacher/delete-teacher.component';
import { RouterLink, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { GetAllTeacherComponent } from './components/get-all-teacher/get-all-teacher.component';
import { GetTeacherDetailsComponent } from './components/get-teacher-details/get-teacher-details.component';
import { DeleteTeacherDialogComponent } from './components/delete-teacher-dialog/delete-teacher-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { AuthModule } from '@auth0/auth0-angular';
import { environment } from '../../environments/environment.development';
@NgModule({
  declarations: [
    CreateTeacherComponent,
    TeachersHomeComponent,
    GetTeacherComponent,
    UpdateTeacherComponent,
    DeleteTeacherComponent,
    GetAllTeacherComponent,
    GetTeacherDetailsComponent,
    DeleteTeacherDialogComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    RouterLink,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatPaginatorModule,
    MatTableModule,
    MatCardModule,
    MatListModule,
    AuthModule.forRoot(environment.auth),
    // MaterialButtonComponent,
  ],
  exports: [
    CreateTeacherComponent,
    TeachersHomeComponent,
    GetTeacherComponent,
    UpdateTeacherComponent,
    DeleteTeacherComponent,
    GetAllTeacherComponent,
    GetTeacherDetailsComponent,
  ],
})
export class TeachersModule {}
