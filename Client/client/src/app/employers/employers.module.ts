import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployersRoutingModule } from './employers-routing.module';
import { ProjectComponent } from './project/project.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeProjectComponent } from './employee-project/employee-project.component';
import { JobByIdComponent } from './job-by-id/job-by-id.component';

@NgModule({
  declarations: [  
    ProjectComponent, EmployeeProjectComponent, JobByIdComponent,
  ],
  imports: [
    CommonModule,
    EmployersRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports:[
    ProjectComponent,
  ]
})
export class EmployersModule { }
