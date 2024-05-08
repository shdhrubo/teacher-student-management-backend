import { ITeacherWithId } from './../../ITeacherWithId.model';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { ITeacher } from '../../teacher.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TeacherUpdateService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/teachers`;

  constructor(private http: HttpClient) {}

  updateTeacher(
    teacherId: number,
    teacherData: Partial<ITeacherWithId>
  ): Observable<ITeacherWithId> {
    const url = `${this.apiUrl}/${teacherId}`;
    return this.http.put<ITeacherWithId>(url, teacherData);
  }
}
