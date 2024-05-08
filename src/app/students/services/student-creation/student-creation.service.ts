import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { IStudent } from '../../student.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentCreationService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/students`;

  constructor(private http: HttpClient) {}
  createStudent(studentData: IStudent): Observable<IStudent> {
    return this.http.post<IStudent>(this.apiUrl, studentData);
  }
}
