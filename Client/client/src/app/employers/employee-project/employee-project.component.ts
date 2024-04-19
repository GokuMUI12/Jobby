import { Component, OnDestroy, OnInit } from '@angular/core';
import { JobService } from '../job.service';
import { Subscription } from 'rxjs';
import { OfferService } from 'src/app/offer/offer.service';

@Component({
  selector: 'app-employee-project',
  templateUrl: './employee-project.component.html',
  styleUrls: ['./employee-project.component.css']
})
export class EmployeeProjectComponent implements OnInit {
  constructor(public jobService: JobService, public offerService: OfferService) { }
  jobs: any;
  private countSubscription?: Subscription;

  ngOnInit() {
    this.getJobs();

  }

  getJobs() {
    this.jobService.getJobsForUser().subscribe({
      next: (jobs: any) => {
        this.jobs = jobs.result;
        console.log(jobs);
      },
      error: (err: any) => {
        console.error(err);
      }
    });
  }
}
