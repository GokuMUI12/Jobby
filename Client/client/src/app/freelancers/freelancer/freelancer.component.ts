import { Component, OnInit } from '@angular/core';
import { FreelancerService } from '../freelancer.service';
import { UserToReturn } from 'src/app/shared/models/UserToReturn';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-freelancer',
  templateUrl: './freelancer.component.html',
  styleUrls: ['./freelancer.component.css']
})
export class FreelancerComponent implements OnInit {
  freelancers : UserToReturn[] = []
  constructor(public freelancerService : FreelancerService) {}

  ngOnInit() {
    this.getFreelancers();
  }

  getFreelancers() {
    this.freelancerService.getFreelancers().subscribe({
      next : freelancers => {
          this.freelancers = freelancers
          console.log(freelancers)
      },
      error : (err : HttpErrorResponse) => {
          console.log('Cant load freelancers for some reason');
      }
    })
  }

}
