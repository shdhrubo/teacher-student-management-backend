import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITeacher } from '../../teacher.model';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class TeacherCreationService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/teachers`;

  constructor(private http: HttpClient) {}
  createTeacher(teacherData: ITeacher): Observable<ITeacher> {
    const token = localStorage.getItem('jwt_token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post<ITeacher>(this.apiUrl, { teacherData, headers });
  }
}
