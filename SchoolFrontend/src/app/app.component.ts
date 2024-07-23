import { Component } from '@angular/core';
import { SchoolService } from './school.service';
import { catchError, throwError } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  teacherCode: string | undefined;
  studentCode: string | undefined;
  subjectName: string | undefined;
  students: any[] | null = null;
  subjects: any[] | null = null;
  teacher: string | undefined;
  grades: any[] | null = null;
  averageGrade: number | undefined;

  constructor(private schoolService: SchoolService) { }


  loadStudentsForTeacher() {
    if (!this.teacherCode) {
      alert('Please enter a teacher code.');
      return;
    }
    this.del()
    if (this.teacherCode) {
      this.schoolService.getStudentsForTeacher(this.teacherCode).pipe(
        catchError(error => {
          let errorMessage = 'An unknown error occurred.';
          if (error.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${error.error.message}`;
          } else {
            if (error.status === 404) {
              errorMessage = 'No students found for the specified teacher.';
            } else if (error.status === 400) {
              errorMessage = 'Bad request. Please check the teacher code.';
            } else {
              errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
            }
          }
          alert(errorMessage);
          return throwError(() => new Error(errorMessage));
        })
      ).subscribe(data => {
        this.students = data;
      });
    }
  }

  loadSubjectsForTeacher() {
    if (!this.teacherCode) {
      alert('Please enter a teacher code.');
      return;
    }
    this.del()
    if (this.teacherCode) {
      this.schoolService.getSubjectsForTeacher(this.teacherCode).pipe(
        catchError(error => {
          let errorMessage = 'An unknown error occurred.';
          if (error.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${error.error.message}`;
          } else {
            if (error.status === 404) {
              errorMessage = 'No subjects found for the specified teacher.';
            } else if (error.status === 400) {
              errorMessage = 'Bad request. Please check the teacher code.';
            } else {
              errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
            }
          }
          alert(errorMessage);
          return throwError(() => new Error(errorMessage));
        })
      ).subscribe(data => {
        this.subjects = data;
      });
    }
  }

  loadSubjectsForStudent() {
    if (!this.studentCode) {
      alert('Please enter a student code.');
      return;
    }
    this.del()
    if (this.studentCode) {
      this.schoolService.getSubjectsForStudent(this.studentCode).pipe(
        catchError(error => {
          let errorMessage = 'An unknown error occurred.';
          if (error.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${error.error.message}`;
          } else {
            if (error.status === 404) {
              errorMessage = 'No subjects found for the specified student.';
            } else if (error.status === 400) {
              errorMessage = 'Bad request. Please check the student code.';
            } else {
              errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
            }
          }
          alert(errorMessage);
          return throwError(() => new Error(errorMessage));
        })
      ).subscribe(data => {
        this.subjects = data;
      });
    }
  }

  loadTeacherForStudentSubject() {
    if (!this.studentCode || !this.subjectName) {
      alert('Please enter both student code and subject name.');
      return;
    }
    this.del()
    if (this.studentCode && this.subjectName) {
      this.schoolService.getTeacherForStudentSubject(this.studentCode, this.subjectName).pipe(
        catchError(error => {
          let errorMessage = 'An unknown error occurred.';
          if (error.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${error.error.message}`;
          } else {
            if (error.status === 404) {
              errorMessage = 'No teacher found for the specified student and subject.';
            } else if (error.status === 400) {
              errorMessage = 'Bad request. Please check the student code and subject name.';
            } else {
              errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
            }
          }
          alert(errorMessage);
          return throwError(() => new Error(errorMessage));
        })
      ).subscribe(data => {
        this.teacher = data;
      });
    }
  }

  loadGradesForStudentSubject() {
    if (!this.studentCode || !this.subjectName) {
      alert('Please enter both student code and subject name.');
      return;
    }
    this.del();
    if (this.studentCode && this.subjectName) {
      this.schoolService.getGradesForStudentSubject(this.studentCode, this.subjectName).pipe(
        catchError(error => {
          let errorMessage = 'An unknown error occurred.';
          if (error.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${error.error.message}`;
          } else {
            if (error.status === 404) {
              errorMessage = 'No grades found for the specified student and subject.';
            } else if (error.status === 400) {
              errorMessage = 'Bad request. Please check the student code and subject name.';
            } else {
              errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
            }
          }
          alert(errorMessage);
          return throwError(() => new Error(errorMessage));
        })
      ).subscribe(data => {
        this.grades = data;
      });
    }
  }

  loadAverageGradeForStudentSubject() {
    if (!this.studentCode || !this.subjectName) {
      alert('Please enter both student code and subject name.');
      return;
    }
    this.del()
    if (this.studentCode && this.subjectName) {
      this.schoolService.getAverageGradeForStudentSubject(this.studentCode, this.subjectName).pipe(
        catchError(error => {
          let errorMessage = 'An unknown error occurred.';
          if (error.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${error.error.message}`;
          } else {
            if (error.status === 404) {
              errorMessage = 'No grades found for the specified student and subject.';
            } else if (error.status === 400) {
              errorMessage = 'Bad request. Please check the student code and subject name.';
            } else {
              errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
            }
          }
          alert(errorMessage);
          return throwError(() => new Error(errorMessage));
        })
      ).subscribe(data => {
        this.averageGrade = data;
      });
    }
  }

  del() {
    this.subjects = null;
    this.students = null;
    this.teacher = undefined;
    this.grades = null;
    this.averageGrade = undefined
  }
}