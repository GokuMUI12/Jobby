import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../employees.service';
import { HttpErrorResponse } from '@angular/common/http';
import { UserToReturn } from 'src/app/shared/models/UserToReturn';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees? : UserToReturn[] = []
  constructor(public service: EmployeesService) { }

  ngOnInit(): void {
    this.getAllEmployees();
  }

  getAllEmployees() {
     this.service.getAllEmployees().subscribe({
      next : (data) =>  {
        this.employees = data
        console.log(this.employees)
      },
      error : (err : HttpErrorResponse) => {
        console.log(err)
      }      
     })
  }


}
