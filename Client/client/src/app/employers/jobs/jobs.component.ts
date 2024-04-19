import { Component, OnInit } from '@angular/core';
import { JobService } from '../job.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {
  jobs : any
  constructor(public jobService : JobService) {}

  ngOnInit() {
    this.getJobs()
  }

  getJobs() {
     this.jobService.getJobs().subscribe({
      next: jobs => {
          this.jobs = jobs
          console.log(this.jobs)
      },
      error : err => {
          console.log(err)
      }
     })
  }
}
