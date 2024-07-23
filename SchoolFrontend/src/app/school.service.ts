import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {
  private baseUrl = 'https://localhost:5001/api/School';
  constructor(private http: HttpClient) { }

  getAllTeachers(): Observable<any> {
    return this.http.get(`${this.baseUrl}/GetAllTeachers`);
  }

  getStudentsForTeacher(teacherCode: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/GetStudentsForTeacher/${teacherCode}`);
  }

  getSubjectsForTeacher(teacherCode: string): Observable<any> {
    return this.http.get<any[]>(`${this.baseUrl}/GetSubjectsForTeacher/${teacherCode}`);
  }

  getSubjectsForStudent(studentCode: string): Observable<any> {
    return this.http.get<any[]>(`${this.baseUrl}/GetSubjectsForStudent/${studentCode}`);
  }

  getTeacherForStudentSubject(studentCode: string, subjectName: string): Observable<string> {
    const params = new HttpParams()
      .set('studentCode', studentCode)
      .set('subjectName', subjectName);
    return this.http.get<string>(`${this.baseUrl}/GetTeacherForStudentSubject`, { params, responseType: 'text' as 'json'  });
  }

  getGradesForStudentSubject(studentCode: string, subjectName: string): Observable<any> {
    const params = new HttpParams()
      .set('studentCode', studentCode)
      .set('subjectName', subjectName);
    return this.http.get<any[]>(`${this.baseUrl}/GetGradesForStudentSubject`, { params });
  }

  getAverageGradeForStudentSubject(studentCode: string, subjectName: string): Observable<number> {
    const params = new HttpParams()
      .set('studentCode', studentCode)
      .set('subjectName', subjectName);
    return this.http.get<number>(`${this.baseUrl}/GetAverageGradeForStudentSubject`, { params });
  }
}

