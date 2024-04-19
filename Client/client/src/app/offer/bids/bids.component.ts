import { Component, OnInit } from '@angular/core';
import { OfferService } from '../offer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bids',
  templateUrl: './bids.component.html',
  styleUrls: ['./bids.component.css']
})
export class BidsComponent implements OnInit {
    offers: any
 
  constructor(public offerService: OfferService, public route: ActivatedRoute) { }

  ngOnInit() {
    this.getBids()

  }
  getBids() {
    let jobId = this.route.snapshot.paramMap.get('id');
    if (jobId) {
      this.offerService.getJobOffers(+jobId).subscribe({
        next: offers => {
          this.offers = offers;
          console.log(this.offers);    
        },
        error: err => {
          console.error(err);
        }
      });
    }
  }
}
