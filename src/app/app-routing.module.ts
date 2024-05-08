import { StudentsModule } from './students/students.module';
import { TeachersModule } from './teachers/teachers.module';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TeachersHomeComponent } from './teachers/components/teachers-home/teachers-home.component';
import { StudentsHomeComponent } from './students/components/students-home/students-home.component';
import { CreateTeacherComponent } from './teachers/components/create-teacher/create-teacher.component';
import { GetTeacherComponent } from './teachers/components/get-teacher/get-teacher.component';
import { CreateStudentComponent } from './students/components/create-student/create-student.component';
import { GetStudentComponent } from './students/components/get-student/get-student.component';
import { GetAllTeacherComponent } from './teachers/components/get-all-teacher/get-all-teacher.component';
import { UpdateTeacherComponent } from './teachers/components/update-teacher/update-teacher.component';
import { DeleteTeacherComponent } from './teachers/components/delete-teacher/delete-teacher.component';
import { GetTeacherDetailsComponent } from './teachers/components/get-teacher-details/get-teacher-details.component';
import { GetAllStudentComponent } from './students/components/get-all-student/get-all-student.component';
import { UpdateStudentComponent } from './students/components/update-student/update-student.component';
import { DeleteStudentComponent } from './students/components/delete-student/delete-student.component';
import { GetStudentDetailsComponent } from './students/components/get-student-details/get-student-details.component';
import { RegistrationComponent } from './authentication/components/registration/registration.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { LoginComponent } from './authentication/components/login/login.component';
import { AuthGuard } from '@auth0/auth0-angular';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'signup',
    component: RegistrationComponent,
  },
  {
    path: 'signin',
    component: LoginComponent,
  },
  {
    path: 'teachers',
    canActivate: [AuthGuard],
    children: [
      { path: '', component: TeachersHomeComponent },
      {
        path: 'create',
        component: CreateTeacherComponent,
      },
      {
        path: 'get-teacher',
        component: GetTeacherComponent,
      },
      {
        path: 'get-all-teachers',
        component: GetAllTeacherComponent,
      },
      {
        path: 'update-teacher/:id',
        component: UpdateTeacherComponent,
      },
      {
        path: 'delete-teacher/:id',
        component: DeleteTeacherComponent,
      },
      {
        path: 'get-teacher-details/:id',
        component: GetTeacherDetailsComponent,
      },
    ],
  },
  {
    path: 'students',
    canActivate: [AuthGuard],
    children: [
      { path: '', component: StudentsHomeComponent },
      {
        path: 'create',
        component: CreateStudentComponent,
      },
      {
        path: 'get-student',
        component: GetStudentComponent,
      },
      {
        path: 'get-all-students',
        component: GetAllStudentComponent,
      },
      {
        path: 'update-student/:id',
        component: UpdateStudentComponent,
      },
      {
        path: 'delete-student/:id',
        component: DeleteStudentComponent,
      },
      {
        path: 'get-student-details/:id',
        component: GetStudentDetailsComponent,
      },
    ],
  },
];

@NgModule({
  imports: [
    AuthenticationModule,
    TeachersModule,
    StudentsModule,
    AuthenticationModule,
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
