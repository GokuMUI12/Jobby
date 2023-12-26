import { Component, OnInit } from '@angular/core';
import { JobService } from '../job.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job-by-id',
  templateUrl: './job-by-id.component.html',
  styleUrls: ['./job-by-id.component.css']
})
export class JobByIdComponent implements OnInit {
  job?: any
  constructor(public jobService: JobService, public route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getJob()
  }

  getJob() {
    const id = this.route.snapshot.paramMap.get('id');
    if(!id) return

    this.jobService.getJobById(+id).subscribe({
      next : job => this.job = job.result      
    })    
  }
  

}
