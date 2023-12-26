import { Component, OnInit, inject } from '@angular/core';
import { JobService } from '../job.service';
import { Job } from 'src/app/shared/models/job';

@Component({
  selector: 'app-employee-project',
  templateUrl: './employee-project.component.html',
  styleUrls: ['./employee-project.component.css']
})
export class EmployeeProjectComponent implements OnInit {

  jobs: any;
  jobService = inject(JobService)

  ngOnInit(): void {
    this.getJobs();
  }

  getJobs() {
      this.jobService.getJobsForUser().subscribe((jobs : any) => {
            this.jobs = jobs.result;
      })
  }

}
