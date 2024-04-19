import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FreelancersRoutingModule } from './freelancers-routing.module';
import { FreelancerComponent } from './freelancer/freelancer.component';


@NgModule({
  declarations: [
    FreelancerComponent
  ],
  imports: [
    CommonModule,
    FreelancersRoutingModule
  ]
})
export class FreelancersModule { }
