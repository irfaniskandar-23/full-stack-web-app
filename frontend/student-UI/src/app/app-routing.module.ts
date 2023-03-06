import { EditStudentComponent } from './components/students/edit-student/edit-student.component';
import { AddStudentComponent } from './components/students/add-student/add-student.component';
import { StudentsListComponent } from './components/students/students-list/students-list.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: StudentsListComponent
  },

  {
    path: 'students',
    component: StudentsListComponent
  },
  {
    path: 'student/register',
    component: AddStudentComponent
  },
  {
    path: 'student/:id',
    component: EditStudentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
