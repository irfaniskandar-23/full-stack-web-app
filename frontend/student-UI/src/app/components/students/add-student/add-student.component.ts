import { StudentsService } from 'src/app/services/students.service';
import { compileNgModule } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student.model'
import { Router, Routes } from '@angular/router';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {

  addStudentRequest: Student = {
    studentId: '',
    name: '',
    matricId: '',
    email: '',
    contact: '',
    gender: '',
    courseName: ''
  };
  constructor(private studentService: StudentsService, private router: Router) { }

  ngOnInit(): void {
  }

  addStudent() {
    this.studentService.addStudent(this.addStudentRequest)
      .subscribe({
        next: (student) => {
          this.router.navigate(['students'])
          //console.log(student);

        },
        error: (response) => {
          console.log(response);
        }
      })
  }

}
