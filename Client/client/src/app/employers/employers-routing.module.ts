import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectComponent } from './project/project.component';
import { EmployeeProjectComponent } from './employee-project/employee-project.component';
import { JobByIdComponent } from './job-by-id/job-by-id.component';
import { JobsComponent } from './jobs/jobs.component';

const routes: Routes = [{path: '', component : ProjectComponent},
    {path: 'user-jobs', component: EmployeeProjectComponent},
    {path: 'jobs', component: JobsComponent},
    {path: ':id', component: JobByIdComponent} ,
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployersRoutingModule { }
