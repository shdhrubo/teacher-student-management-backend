import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { IStudentWithId } from '../../IStudentWithId.model';

@Injectable({
  providedIn: 'root',
})
export class StudentGetService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/students`;

  constructor(private http: HttpClient) {}

  getStudentById(studentId: number): Observable<IStudentWithId> {
    const token = localStorage.getItem('jwt_token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const url = `${this.apiUrl}/${studentId}`;
    return this.http.get<IStudentWithId>(url, { headers });
  }
}
