import { ITeacherWithId } from './../../ITeacherWithId.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TeacherGetService {
  private domain = environment.domain;
  private apiUrl = `${this.domain}/teachers`;

  constructor(private http: HttpClient) {}

  getTeacherById(teacherId: number): Observable<ITeacherWithId> {
    const url = `${this.apiUrl}/${teacherId}`;
    return this.http.get<ITeacherWithId>(url);
  }
}
