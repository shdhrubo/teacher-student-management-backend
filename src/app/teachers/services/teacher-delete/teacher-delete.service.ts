import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITeacher } from '../../teacher.model';

@Injectable({
  providedIn: 'root'
})
export class TeacherDeleteService {

  private domain = environment.domain;
  private apiUrl = `${this.domain}/teachers`;


  constructor(private http: HttpClient) {}

deleteTeacher(teacherId: number): Observable<ITeacher> {
    const url = `${this.apiUrl}/${teacherId}`;
    return this.http.delete<ITeacher>(url);
  }
}
