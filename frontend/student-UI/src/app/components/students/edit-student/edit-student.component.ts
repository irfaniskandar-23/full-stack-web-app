import { Student } from 'src/app/models/student.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentsService } from 'src/app/services/students.service';
import { Router, Routes } from '@angular/router';


@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {

  studentDetails: Student = {
    studentId: '',
    name: '',
    matricId: '',
    email: '',
    contact: '',
    gender: '',
    courseName: ''
  };
  constructor(private route: ActivatedRoute, private studentService: StudentsService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.studentService.getStudent(id).subscribe({
            next: (response) => {
              this.studentDetails = response;

            }
          })
        }
      }
    })
  }

  updateStudent() {
    this.studentService.updateStudent(this.studentDetails.studentId, this.studentDetails)
      .subscribe({
        next: (response) => {
          this.router.navigate(['students']);
        }
      })
  }

  deleteStudent(id: string) {
    if (confirm("Are you sure to delete"))
      this.studentService.deleteStudent(id)
        .subscribe({
          next: (response) => {
            this.router.navigate(['students']);
          }
        })
  }
}
