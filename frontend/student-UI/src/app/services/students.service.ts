import { Student } from './../models/student.model';

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.baseApiUrl + 'api/student/student-list')
  }

  addStudent(addStudentRequest: Student): Observable<Student> {
    addStudentRequest.studentId = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Student>(this.baseApiUrl + 'api/student/register', addStudentRequest)
  }

  getStudent(id: string): Observable<Student> {
    return this.http.get<Student>(this.baseApiUrl + 'api/student/' + id)
  }

  updateStudent(id: string, updateStudentRequest: Student): Observable<Student> {
    return this.http.put<Student>(this.baseApiUrl + 'api/student/' + id, updateStudentRequest)
  }

  deleteStudent(id: string): Observable<Student> {
    return this.http.delete<Student>(this.baseApiUrl + 'api/student/' + id);
  }
}
