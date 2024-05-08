// import { Injectable } from '@angular/core';
// import { Observable, delay } from 'rxjs';
// import { ITeacher } from '../../teacher.model';
// import { environment } from '../../../../environments/environment.development';
// import { HttpClient } from '@angular/common/http';
// @Injectable({
//   providedIn: 'root',
// })
// export class TeacherGetAllService {
//   private domain = environment.domain;
//   private apiUrl = `${this.domain}/teachers`;
//   constructor(private http: HttpClient) {}
//   getTeachers(): Observable<any> {
//     return this.http.get(this.apiUrl);
//   }
// }
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '@auth0/auth0-angular';

@Injectable({
  providedIn: 'root',
})
export class TeacherGetAllService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/teachers`;

  constructor(private http: HttpClient, public auth: AuthService) {}

  // getTeachers(pageNumber: number = 1, pageSize: number = 10): Observable<any> {
  //   const params = {
  //     pageNumber: pageNumber.toString(),
  //     pageSize: pageSize.toString(),
  //   };
  //   const token = localStorage.getItem('jwt_token');
  //   console.log(token);
  //   const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  //   return this.http.get(this.apiUrl, { params, headers });
  // }

  getTeachers(pageNumber: number = 1, pageSize: number = 10): Observable<any> {
    const params = {
      pageNumber: pageNumber.toString(),
      pageSize: pageSize.toString(),
    };

    return this.http.get(this.apiUrl, { params }).pipe(
      catchError((error) => {
        console.error('Error fetching data:', error);
        return throwError(error);
      })
    );
  }
}
