import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { IStudent } from '../../student.model';

@Injectable({
  providedIn: 'root',
})
export class StudentDeleteService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/students`;

  constructor(private http: HttpClient) {}

  deleteStudent(studentId: number): Observable<IStudent> {
    const url = `${this.apiUrl}/${studentId}`;
    return this.http.delete<IStudent>(url);
  }
}
