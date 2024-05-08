import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { IStudentWithId } from '../../IStudentWithId.model';

@Injectable({
  providedIn: 'root',
})
export class StudentUpdateService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/students`;

  constructor(private http: HttpClient) {}

  updateStudent(
    studentId: number,
    studentData: Partial<IStudentWithId>
  ): Observable<IStudentWithId> {
    const url = `${this.apiUrl}/${studentId}`;
    return this.http.put<IStudentWithId>(url, studentData);
  }
}
